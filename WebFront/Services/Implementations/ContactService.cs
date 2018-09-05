using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFront.Models;
using WebFront.Repositories.UoW;

namespace WebFront.Services.Implementations
{
    public class ContactService : IContactService
    {
        private IUnitOfWork _unitOfWork;
        private string error;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            error = string.Empty;
        }

        public string GetError()
        {
            return error;
        }

        public ICollection<Contact> GetAll()
        {
            return _unitOfWork.ContactRepository.GetAll();
        }

        public ICollection<Contact> GetByCompanyId(int id)
        {
            return _unitOfWork.ContactRepository.GetByCompanyId(id);
        }

        public Contact GetById(int id)
        {
            var contact = _unitOfWork.ContactRepository.GetById(id);
            if(contact == null)
            {
                error = "Not found";
                return null;
            }

            var company = _unitOfWork.CompanyRepository.GetById(contact.CompanyId);
            var notes = _unitOfWork.NoteRepository.GetByContactId(id);
            contact.Company = company;
            contact.Notes = notes;
            return contact;
        }

        public bool Add(Contact entity)
        {
            try
            {
                _unitOfWork.ContactRepository.Add(entity);
                _unitOfWork.ContactRepository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                error = "Entry not added";
                return false;
            }
        }

        public bool Update(Contact entity)
        {
            try
            {
                _unitOfWork.ContactRepository.Update(entity);
                _unitOfWork.ContactRepository.SaveChanges();
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