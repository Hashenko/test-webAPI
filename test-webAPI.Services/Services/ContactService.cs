using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounter.DB.Entities;
using Accounter.DB.UnitOfWork;
using Accounter.Services.Interfaces;

namespace Accounter.Services.Services
{
    public class ContactService : BaseService, IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public new void Create<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var contact = entity as Contact;
            var contacts = Get<Contact>();
            var oldContact = contacts.FirstOrDefault(i => i.Email == contact.Email);
            if (oldContact != null)
            {

                contact.Id = oldContact.Id;
                _unitOfWork.Detach<Contact>(oldContact);
                _unitOfWork.Update(contact);
                return;
            }

            _unitOfWork.Insert(contact);
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
