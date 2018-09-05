using System;
using System.Collections.Generic;
using WebFront.Models;
using WebFront.Repositories.UoW;

namespace WebFront.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork _unitOfWork;
        private string error;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            error = string.Empty;
        }

        public string GetError()
        {
            return error;
        }

        public ICollection<Company> GetAll()
        {
            return _unitOfWork.CompanyRepository.GetAll();
        }

        public Company GetById(int id)
        {
            var company = _unitOfWork.CompanyRepository.GetById(id);
            if(company == null)
            {
                error = "Not Found";
                return null;
            }

            var region = _unitOfWork.RegionRepository.GetById(company.RegionId);
            var contacts = _unitOfWork.ContactRepository.GetByCompanyId(id);
            company.Region = region;
            company.Contacts = contacts;
            return company;
        }

        public ICollection<Company> GetByRegionId(int id)
        {
            return _unitOfWork.CompanyRepository.GetByRegionId(id);
        }

        public bool Add(Company entity)
        {
            try
            {
                _unitOfWork.CompanyRepository.Add(entity);
                _unitOfWork.CompanyRepository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                error = "Entry not added";
                return false;
            }
        }

        public bool Update(Company entity)
        {
            try
            {
                _unitOfWork.CompanyRepository.Update(entity);
                _unitOfWork.CompanyRepository.SaveChanges();
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