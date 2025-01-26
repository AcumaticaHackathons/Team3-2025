using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.SO;
using PX.SM;
using PX.SM.Alias;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using PX.Common;


namespace Hackathon2025Team3
{
    public class NTSOOrderEntryExt : PXGraphExtension<SOOrderEntry>
    {
        public static bool IsActive() => true;        

        #region Views
        public SelectFrom<NTNoteGroups>.Where<NTNoteGroups.noteid.IsEqual<SOOrder.noteID.FromCurrent>>.View NTNotesGroups;

        public SelectFrom<NTNote>.Where<NTNote.groupID.IsEqual<NTNoteGroups.groupID.FromCurrent>>.View NTNotes;

        public SelectFrom<NTNote>.Where<NTNote.groupID.IsEqual<NTNoteGroups.groupID.FromCurrent>>.View NTNotesList;
        #endregion

        #region Event Handlers
        public virtual void _(Events.RowInserted<SOOrder> e)
        {
            SOOrder Row = (SOOrder)e.Row;
            if (Row == null)
            {
                return;
            }

            if (Row.NoteID != null)
            {
                if (NTNotesGroups.Select().Count == 0)
                {
                    NTNoteGroups NewNoteGroup = new NTNoteGroups();
                    NewNoteGroup.GroupID = Guid.NewGuid();
                    NewNoteGroup.Noteid = Row.NoteID;
                    NTNotesGroups.Insert(NewNoteGroup);
                }
            }
        }

        public virtual void _(Events.RowInserting<NTNote> e)
        {
            NTNote Row = (NTNote)e.Row;
            if (Row == null)
            {
                return;
            }

            NTNoteGroups Group = this.NTNotesGroups.Select().FirstOrDefault();
            if (Group == null)
            {
                return;
            }

            Row.GroupID = Group.GroupID;
        }
        #endregion

        #region Actions
        public PXAction<SOOrder> AddNewNote;
        [PXUIField(DisplayName = "Add Note")]
        [PXButton]
        public virtual IEnumerable addNewNote(PXAdapter adapter)
        {
            //this.NTNotes.Cache.Clear();

            //NTNote NewNote = new NTNote();
            //NewNote = NTNotes.Insert(NewNote);

            if (this.NTNotes.AskExt() == WebDialogResult.OK)
            {
               // base.Base.Save.Press();
            }

            return adapter.Get();
        }

        public PXAction<SOOrder> InsertItem;
        [PXButton()]
        [PXUIField(DisplayName = "Add")]
        public IEnumerable insertItem(PXAdapter adapter)
        {
            NTNote NewNote = NTNotes.Current;
            if (NewNote == null)
            {
                return adapter.Get();
            }
            var userName = Base.Accessinfo.UserName;
            var companyName = Base.Accessinfo.CompanyName;
            var user = userName + "@" + companyName;
            var groupID = NTNotesGroups.Select().RowCast<NTNoteGroups>().FirstOrDefault().GroupID ?? Guid.NewGuid();
            var userGUI = Base.Accessinfo.UserID;
            //PErform a PXDatabase.Insert for NTNote
            PXDatabase.Insert(typeof(NTNote), 
                new PXDataFieldAssign("GroupID",PXDbType.UniqueIdentifier,
                   groupID ),
                new PXDataFieldAssign("NoteText", PXDbType.NVarChar,
                   NewNote.NoteText),
                new PXDataFieldAssign("CreatedByID", PXDbType.UniqueIdentifier, userGUI),
                new PXDataFieldAssign("CreatedByScreenID", PXDbType.Char,8, "SO301000"),
                new PXDataFieldAssign("LastModifiedByScreenID", PXDbType.Char,8, "SO301000"),

                new PXDataFieldAssign("CreatedDateTime", PXDbType.DateTime,
                   PXTimeZoneInfo.Now),
                new PXDataFieldAssign("LastModifiedByID", PXDbType.UniqueIdentifier,
                   userGUI),
                new PXDataFieldAssign("LastModifiedDateTime", PXDbType.DateTime,
                   PXTimeZoneInfo.Now)
               
                );
            NTNotes.Current.NoteText = string.Empty;

            return adapter.Get();
        }

            #endregion
        }
}