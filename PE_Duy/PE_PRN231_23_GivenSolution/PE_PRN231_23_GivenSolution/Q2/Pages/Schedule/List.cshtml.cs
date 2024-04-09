using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Services;
using Q2.ViewModel;
using System.Net.Http;
using System.Text.Json;

namespace Q2.Pages.Schedule
{
    public class ListModel : PageModel
    {

        [BindProperty]
        public string InputTime { get; set; }

        public List<ScheduleViewModel> ListSchedule { get; set; }
        public List<RoomViewModel> ListRoom { get; set; }
        public List<TimeSlotViewModel> ListTimeSlot { get; set; }
        public List<MovieViewModel> ListMovies { get; set; }


        public async Task<IActionResult> OnGetAsync(string dateInput)
        {
            if (dateInput != null)
            {
                InputTime = DateTime.Parse(dateInput).ToString("MM/dd/yyyy");
            }
            var client = new ClientService(HttpContext);
            ListSchedule = await client.GetDetail<List<ScheduleViewModel>>("/api/Schedule/List/", dateInput);
            ListRoom = await client.GetAll<List<RoomViewModel>>("/api/Room/List");
            ListTimeSlot = await client.GetAll<List<TimeSlotViewModel>>("/api/TimeSlot/List");
            ListMovies = await client.GetAll<List<MovieViewModel>>("/api/Movie/List");


            var list = new List<ScheduleResponseViewModel>();
            var sche = new ScheduleResponseViewModel();
            foreach (var item in ListRoom)
            {
                foreach (var item1 in ListSchedule)
                {
                    if (item1.RoomId == item.Id)
                    {
                        sche.RoomName = item.Title;
                        list.Add(sche);
                    }
                }
            }



            return Page();
        }


    }
}
