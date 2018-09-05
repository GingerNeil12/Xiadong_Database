using System;
using System.Collections.Generic;
using WebFront.Models;
using WebFront.Repositories.UoW;

namespace WebFront.Services.Implementations
{
    public class NoteService : INoteService
    {
        private IUnitOfWork _unitOfWork;
        private string error;

        public NoteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            error = string.Empty;
        }

        public string GetError()
        {
            throw new NotImplementedException();
        }

        public ICollection<Note> GetAll()
        {
            return _unitOfWork.NoteRepository.GetAll();
        }

        public ICollection<Note> GetByContactId(int id)
        {
            return _unitOfWork.NoteRepository.GetByContactId(id);
        }

        public Note GetById(int id)
        {
            var note = _unitOfWork.NoteRepository.GetById(id);
            if(note == null)
            {
                error = "Not found";
                return null;
            }

            var contact = _unitOfWork.ContactRepository.GetById(note.ContactId);
            note.Contact = contact;
            return note;
        }

        public bool Add(Note entity)
        {
            try
            {
                _unitOfWork.NoteRepository.Add(entity);
                _unitOfWork.NoteRepository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                error = "Entry not added";
                return false;
            }
        }

        public bool Update(Note entity)
        {
            try
            {
                _unitOfWork.NoteRepository.Update(entity);
                _unitOfWork.NoteRepository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                error = "Entry not updated";
                return false;
            }
        }

        public void Dispose()
        {
            if(_unitOfWork != null)
            {
                _unitOfWork.Dispose();
                _unitOfWork = null;
            }
            error = string.Empty;
            GC.SuppressFinalize(this);
        }
    }
}