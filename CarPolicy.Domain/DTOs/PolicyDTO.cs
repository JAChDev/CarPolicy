using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain.DTOs
{
    public class PolicyDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("PolicyNumber")]
        public string? PolicyNumber { get; set; }

        [BsonElement("CustomerName")]
        public string? CustomerName { get; set; }

        [BsonElement("CustomerId")]
        public string? CustomerId { get; set; }

        [BsonElement("CustomerBirth")]
        public DateTime CustomerBirth { get; set; }

        [BsonElement("PolicyStartDate")]
        public DateTime PolicyStartDate { get; set; }

        [BsonElement("PolicyEndDate")]
        public DateTime PolicyEndDate { get; set; }

        [BsonElement("Coverages")]
        public string[]? Coverages { get; set; }

        [BsonElement("MaxPolicyAmount")]
        public decimal MaxPolicyAmount { get; set; }

        [BsonElement("PlanName")]
        public string? PlanName { get; set; }

        [BsonElement("CustomerCity")]
        public string? CustomerCity { get; set; }

        [BsonElement("CustomerAddress")]
        public string? CustomerAddress { get; set; }

        [BsonElement("VehiclePlate")]
        public string? VehiclePlate { get; set; }

        [BsonElement("VehicleModel")]
        public string? VehicleModel { get; set; }

        [BsonElement("Inspection")]
        public bool Inspection { get; set; }
    }
}
