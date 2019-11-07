using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.DAL.Entities
{
    public class Flight : BaseEntity
    {
        public int MeansOfTransportId { get; set; }
        public int? WhereToId { get; set; }
        public int? FromWhereId { get; set; }

        public virtual City FromWhere { get; set; }
        public virtual City WhereTo { get; set; }
        public virtual MeansOfTransport MeansOfTransport { get; set; }
        public Flight()
        {
        }

        public Flight(int meansOfTransportId, int? whereToId, int? fromWhereId)
        {
            MeansOfTransportId = meansOfTransportId;
            WhereToId = whereToId;
            FromWhereId = fromWhereId;
        }
    }
}
