using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Csla;

namespace Library
{
    [Serializable]
    public class PersonEdit : BusinessBase<PersonEdit>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
        [Display(Name = "First name")]
        [Required]
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
            set { SetProperty(FirstNameProperty, value); }
        }

        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
        [Display(Name = "Last name")]
        [Required]
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            set { SetProperty(LastNameProperty, value); }
        }

        public static void GetPersonEdit(int id, EventHandler<DataPortalResult<PersonEdit>> callback)
        {
            DataPortal.BeginFetch<PersonEdit>(id, callback);
        }

        public static void NewPersonEdit(EventHandler<DataPortalResult<PersonEdit>> callback)
        {
            DataPortal.BeginCreate<PersonEdit>(callback);
        }

        public static PersonEdit NewPersonEdit()
        {
            return DataPortal.Create<PersonEdit>();
        }

        public static PersonEdit GetPersonEdit(int id)
        {
            return DataPortal.Fetch<PersonEdit>(id);
        }

        public static void DeletePersonEdit(int id)
        {
            DataPortal.Delete<PersonEdit>(id);
        }

        [RunLocal]
        protected override void DataPortal_Create()
        {
            using (BypassPropertyChecks)
            {
                Id = -1;
            }
            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(int id)
        {
            using (var dalManager = DataAccess.DalFactory.GetManager())
            {
                var dal = dalManager.GetProvider<DataAccess.IPersonDal>();
                var data = dal.Fetch(id);
                using (BypassPropertyChecks)
                {
                    Id = data.Id;
                    FirstName = data.FirstName;
                    LastName = data.LastName;
                }
            }
            BusinessRules.CheckRules();
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DataAccess.DalFactory.GetManager())
            {
                var dal = dalManager.GetProvider<DataAccess.IPersonDal>();
                using (BypassPropertyChecks)
                {
                    Id = dal.Insert(new DataAccess.PersonDto { FirstName = FirstName, LastName = LastName });
                }
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataAccess.DalFactory.GetManager())
            {
                var dal = dalManager.GetProvider<DataAccess.IPersonDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(new DataAccess.PersonDto { Id = Id, FirstName = FirstName, LastName = LastName });
                }
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (BypassPropertyChecks)
            {
                DataPortal_Delete(Id);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(int id)
        {
            using (var dalManager = DataAccess.DalFactory.GetManager())
            {
                var dal = dalManager.GetProvider<DataAccess.IPersonDal>();
                dal.Delete(id);
            }
        }
    }
}
