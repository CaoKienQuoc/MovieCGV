using BusinessObject;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class MovieModels
    {
        public string Actor { get; set; }
        public long? CinemaRoomId { get; set; }
        public string Content { get; set; }
        public string Director { get; set; }
        public long? Duration { get; set; }
        public DateTime? FromDate { get; set; }

        [Required(ErrorMessage = "Please select an image.")]
        [DataType(DataType.Upload)]
        [Display(Name = "LargeImage")]
        public IFormFile? LargeImage { get; set; }
        public string MovieNameEnglish { get; set; }
        public string MovieNameVn { get; set; }
        public string MovieProductionCompamy { get; set; }

        [Required(ErrorMessage = "Please select an image.")]
        [DataType(DataType.Upload)]
        [Display(Name = "SmallImage")]
        public IFormFile? SmallImage { get; set; }
        public int? Status { get; set; }
        public DateTime? ToDate { get; set; }
        public string Version { get; set; }
    }
}
