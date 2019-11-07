namespace TravelAgency.BLL.BusinessModels
{
    public class FlightBLM
    {
        public int Id { get; set; }
        public int MeansOfTransportId { get; set; }
        public int? WhereToId { get; set; }
        public int? FromWhereId { get; set; }
        public virtual CityBLM FromWhereBLM { get; set; }
        public virtual CityBLM WhereToBLM { get; set; }
        public MeansOfTransportBLM MeansOfTransportBLM { get; set; }
        public FlightBLM()
        {
        }
        public FlightBLM(int id, int meansOfTransportId, int? whereToId, int? fromWhereId, CityBLM fromWhere, CityBLM whereTo, MeansOfTransportBLM meansOfTransport)
        {
            Id = id;
            MeansOfTransportId = meansOfTransportId;
            WhereToId = whereToId;
            FromWhereId = fromWhereId;
            FromWhereBLM = fromWhere;
            WhereToBLM = whereTo;
            MeansOfTransportBLM = meansOfTransport;
        }
    }
}
