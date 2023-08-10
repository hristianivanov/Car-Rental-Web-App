namespace CarRentalSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Blog;

	public class Blog
	{
        public Blog()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(int.MaxValue)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

		public Guid? CreaterId { get; set; }
		public virtual User? Creater { get; set; }
}
}
