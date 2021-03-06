using Newtonsoft.Json;

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("comic")]
    public partial class comic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public comic()
        {
            chapters = new HashSet<chapter>();
            comic_category = new HashSet<comic_category>();
            //thêm mới
            StatusComicId = 4;
            Rating = 0;
            NumRating = 0;
            ReleaseDate = DateTime.Now;
            UpdateAt = DateTime.Now;
        }


        public int ComicId { get; set; }

        [Required] [StringLength(250)] public string NameComic { get; set; }

        [StringLength(256)] public string AuthorComic { get; set; }

        [Column(TypeName = "datetime2")] public DateTime? ReleaseDate { get; set; }

        public int? NationId { get; set; }

        public int? UserId { get; set; }

        public int? Rating { get; set; }

        public int? NumRating { get; set; }

        public int? StatusComicId { get; set; }

        //thêm mới
        [StringLength(2000)] public String SummaryComic { get; set; }

        [StringLength(256)] public string CommicBanner { get; set; }

        [Column(TypeName = "datetime2")] public DateTime? UpdateAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<chapter> chapters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<comic_category> comic_category { get; set; }

        [JsonIgnore] public virtual nation nation { get; set; }

        [JsonIgnore] public virtual status_comic status_comic { get; set; }

        [JsonIgnore] public virtual user user { get; set; }
    }
}