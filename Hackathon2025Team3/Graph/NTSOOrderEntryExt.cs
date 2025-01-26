using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.SO;
using PX.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Hackathon2025Team3
{
    public class NTSOOrderEntryExt : PXGraphExtension<SOOrderEntry>
    {
        public static bool IsActive() => true;

        

        #region Views
        public SelectFrom<NTNoteGroups>.Where<NTNoteGroups.noteid.IsEqual<SOOrder.noteID.FromCurrent>>.View NTNotesGroups;

        public SelectFrom<NTNote>.Where<NTNote.groupID.IsEqual<NTNoteGroups.groupID.FromCurrent>>.View NTNotes;
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
            if (this.NTNotes.AskExt() == WebDialogResult.OK) 
            {
                base.Base.Save.Press();
            }

            return adapter.Get();
        }
        #endregion
    }
}