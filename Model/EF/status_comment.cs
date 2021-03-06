using Newtonsoft.Json;

namespace Model.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class status_comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public status_comment()
        {
            comments = new HashSet<comment>();
        }

        [Key]
        public int StatusCommentId { get; set; }

        [StringLength(150)]
        public string StatusCommentName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<comment> comments { get; set; }
    }
}
