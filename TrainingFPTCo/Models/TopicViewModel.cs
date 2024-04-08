using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainingFPTCo.Validations;

namespace TrainingFPTCo.Models
{
    public class TopicViewModel
    {
        public List<TopicDetail> TopicDetailsList { get; set; }
    }

    public class TopicDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose a Course")]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please enter the topic's name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose a status")]
        public string Status { get; set; }

        public string Documents { get; set; }
        public string AttachFiles { get; set; }
        public string TypeDocument { get; set; }
        public string PosterTopic { get; set; }

        [Required(ErrorMessage = "Please choose a file for the topic's poster")]
        [AllowExtensionFile(new string[] { ".png", ".jpg", ".jpeg" })]
        [AllowSizeFile(5 * 1024 * 1024)]
        public IFormFile PosterImage { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
