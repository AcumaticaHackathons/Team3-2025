using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.SO;
using PX.SM;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Hackathon2025Team3
{
    public class NTSOOrderEntryExt : PXGraphExtension<SOOrderEntry>
    {
        public static bool IsActive() => true;

        public void Initialize() 
        { 
            
        }

        #region Views
        public SelectFrom<NTNoteGroups>.Where<NTNoteGroups.NoteID.IsEqual<SOOrder.noteID.FromCurrent>>.View NTNotesGroups;

        public SelectFrom<NTNote>.Where<NTNote.GroupID.IsEqual<NTNoteGroups.GroupID.FromCurrent>>.View NTNotes;
        #endregion

        #region Actions
        public PXAction<SOOrder> AddNewNote;
        [PXUIField(DisplayName = "Add Note")]
        [PXButton]
        public virtual IEnumerable addNewNote(PXAdapter adapter)
        {
            this.NTNotes.AskExt();

            return adapter.Get();
        }
        #endregion
    }
}