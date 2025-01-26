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
    public class NTSOShipmentEntryExt : PXGraphExtension<SOShipmentEntry>
    {
        public static bool IsActive() => true;

        #region Views
        public SelectFrom<NTNoteGroups>.Where<NTNoteGroups.noteid.IsEqual<SOShipment.noteID.FromCurrent>>.View NTNotesGroups;

        public SelectFrom<GetShipmentNotes>.Where<GetShipmentNotes.shipmentNbr.IsEqual<SOShipment.shipmentNbr.FromCurrent>>.View NTNotes;
        
        #endregion

        #region Event Handlers
        public virtual void _(Events.RowInserted<SOShipment> e)
        {
            SOShipment Row = (SOShipment)e.Row;
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
        public PXAction<SOShipment> AddNewNote;
        [PXUIField(DisplayName = "Add Note")]
        [PXButton]
        public virtual IEnumerable addNewNote(PXAdapter adapter)
        {
            if (this.NTNotes.AskExt() == WebDialogResult.OK)
            {
            }

            return adapter.Get();
        }
        #endregion
    }
}