using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tadkar.Core.Aggregates.Cities;
using Tadkar.Core.Aggregates.Personnels.Rules;

namespace Tadkar.Core.Aggregates.Personnels
{
    public class Personnel : Entity
    {
        private Personnel() { }

        [Key]
        public int Id { get; private set; }

        [StringLength(50)]
        public string FirstName { get; private set; }

        [StringLength(50)]
        public string LastName { get; private set; }

        public string Address { get; private set; }

        public int City_Id { get; private set; }

        public int Province_Id { get; private set; }


        public static Personnel Create(string firstName, string lastName)
        {
            var personnel = new Personnel();

            CheckRule(new FirstNameCannotBeEmptyRule(firstName));
            CheckRule(new LastNameCannotBeEmptyRule(lastName));

            personnel.FirstName = firstName;
            personnel.LastName = lastName;

            return personnel;
        }

        public void ChangeFirsName(string firstName)
        {
            if (FirstName == firstName)
                return;

            CheckRule(new FirstNameCannotBeEmptyRule(firstName));

            FirstName = firstName;
        }

        public void ChangeLastName(string lastName)
        {
            if (LastName == lastName)
                return;

            CheckRule(new LastNameCannotBeEmptyRule(lastName));

            LastName = lastName;
        }

        public void ChangeAddress(string address)
        {
            if (Address == address)
                return;

            Address = address;
        }

        public void Delete()
        {
            if (CanBeDeleted())
                throw new InvalidOperationException();

            MarkAsDeleted();
        }

        [ForeignKey("City_Id")]
        public virtual City City { get; set; }
    }
}
