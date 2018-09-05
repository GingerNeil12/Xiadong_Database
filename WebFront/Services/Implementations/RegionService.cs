using System;
using System.Collections.Generic;
using WebFront.Models;
using WebFront.Repositories.UoW;

namespace WebFront.Services.Implementations
{
    public class RegionService : IRegionService
    {
        private IUnitOfWork _unitOfWork;
        private string error;

        public RegionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            error = string.Empty;
        }

        public string GetError()
        {
            return error;
        }

        public ICollection<Region> GetAll()
        {
            return _unitOfWork.RegionRepository.GetAll();
        }

        public Region GetById(int id)
        {
            var region = _unitOfWork.RegionRepository.GetById(id);
            if(region == null)
            {
                error = "Not found";
                return null;
            }

            var companies = _unitOfWork.CompanyRepository.GetByRegionId(id);
            region.Companies = companies;
            return region;
        }

        public bool Add(Region entity)
        {
            try
            {
                _unitOfWork.RegionRepository.Add(entity);
                _unitOfWork.RegionRepository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                error = "Entry not added";
                return false;
            }
        }

        public bool Update(Region entity)
        {
            try
            {
                _unitOfWork.RegionRepository.Update(entity);
                _unitOfWork.RegionRepository.SaveChanges();
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