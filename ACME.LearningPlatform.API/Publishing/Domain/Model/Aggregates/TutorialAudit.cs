using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;

public partial class Tutorial: IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}