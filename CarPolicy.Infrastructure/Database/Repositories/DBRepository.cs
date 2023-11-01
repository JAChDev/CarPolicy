using CarPolicy.Domain.DTOs;
using CarPolicy.Domain.Interfaces;
using CarPolicy.Domain.Responses;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarPolicy.Infrastructure.Database.Repositories
{
    public class DBRepository : IDBRepository
    {
        private readonly IMongoCollection<PolicyDTO> _collection;
        private readonly IConfiguration _configuration;
        private static List<PolicyDTO> _policies = new List<PolicyDTO>(); //Lista para simulación de persistencia
        public DBRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration.GetConnectionString("MongoDbConnection"));
            var database = client.GetDatabase(_configuration.GetConnectionString("DatabaseName"));
            _collection = database.GetCollection<PolicyDTO>(_configuration.GetConnectionString("CollectionName"));
        }
        public Task<GeneralResponse> CreatePolicy(PolicyDTO policy)
        {
            try
            {
                _collection.InsertOne(policy);
                GeneralResponse response = new()
                {
                    Success = true,
                    Message = "Póliza insertada exitosamente"
                };
                return Task.FromResult(response);
            }
            catch
            {
                GeneralResponse response = new()
                {
                    Success = false,
                    Message = "Ocurrió un error al insertar la póliza"
                };
                return Task.FromResult(response);
            }
        }

        public Task<GeneralResponse> CreatePolicySimulation(PolicyDTO policy)
        {
            //Inserta registros en la lista de simulación de persistencia con fines de prueba
            try
            {
                _policies.Add(policy);
                GeneralResponse response = new()
                {
                    Success = true,
                    Message = "Póliza insertada exitosamente"
                };
                return Task.FromResult(response);
            }
            catch
            {
                GeneralResponse response = new()
                {
                    Success = false,
                    Message = "Ocurrió un error al insertar la póliza"
                };
                return Task.FromResult(response);
            }
        }

        public Task<PolicyDTO> GetPolicyByNumberOrPlate(string id)
        {
            try
            {
                var filterPolicyNumber = Builders<PolicyDTO>.Filter.Eq("PolicyNumber", id);
                var filterPlate = Builders<PolicyDTO>.Filter.Eq("VehiclePlate", id);

                PolicyDTO policy = _collection.Find(filterPolicyNumber).FirstOrDefault() == null ?
                    _collection.Find(filterPlate).FirstOrDefault() :
                    _collection.Find(filterPolicyNumber).FirstOrDefault();
                return Task.FromResult(policy);
            }
            catch
            {
                return null;
            }
        }

        public Task<PolicyDTO> GetPolicyByNumberOrPlateSimulation(string id)
        {
            //Consulta a la lista que emula la persistencia de datos con fines de prueba
            PolicyDTO result = _policies.FirstOrDefault(p => p.PolicyNumber == id || p.VehiclePlate == id);
            return Task.FromResult(result);
        }
    }
}
