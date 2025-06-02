using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveBotsWebsite.Models
{
    public class LicenseApplication
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ApplicationType { get; set; }

        public string LicenceClass { get; set; }

        public string UploadedFilePath { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }

}
