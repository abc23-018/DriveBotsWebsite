
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace DriveBots.Views.Home
{
    public class HistoryModel : PageModel
    {
        public List<AppointmentViewModel> Appointments = new List<AppointmentViewModel>();
        //public List<LicenseApplicationViewModel> Applications = new List<LicenseApplicationViewModel>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DriveBots;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Appointments;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            AppointmentViewModel appointment = new AppointmentViewModel();
                            while (reader.Read())
                            {
                                appointment.FirstName = reader["FirstName"].ToString();
                                appointment.LastName = reader["LastName"].ToString();
                                appointment.Email = reader["Email"].ToString();
                                appointment.AppointmentType = reader["AppointmentType"].ToString();
                                appointment.Date = Convert.ToDateTime(reader["Date"]);
                                appointment.Location = reader["Location"].ToString();

                                Appointments.Add(appointment);
                            }
                        }
                    };
                };
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class AppointmentViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string AppointmentType { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }
    }
}
