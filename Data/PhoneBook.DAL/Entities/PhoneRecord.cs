using PhoneBook.DAL.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.DAL.Entities
{
    /// <summary>
    /// Сущность записи телефонной книги
    /// 
    /// </summary>
    public class PhoneRecord : Entity, IEquatable<PhoneRecord>
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Адресс
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        public bool Equals(PhoneRecord other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }
    }
}
