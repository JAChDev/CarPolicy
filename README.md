================================================
API PARA CREAR Y CONSULTAR PÓLIZAS DE VEHÍCULOS
================================================

Esta API permite registrar pólizas de vehículos en una base de datos MongoDB, y consultarlas posteriormente.

La API está protegida con autenticación JWT, para su consumo se requiere un token de autenticación, 
por lo que cuenta con un endpoint login en la ruta "api/auth" que genera el token requerido para su consumo.

===================
Endpoints
===================

Los endpoints POST "api/policy/createPolicy" y GET "api/policy/getPolicy/{data}" corresponden, respectivamente al 
registro y consulta de las pólizas en la base de datos; para implementar la conexión con su base de datos
ingrese al archivo app.settings.Development y agregue el string de conexión, también su base de datos y la 
colección donde almacenará los documentos; si desea, puede crear la base de datos y colecciones sugeridas.

Los endpoints POST "api/policy/createPolicySimulation" y GET "api/policy/getPolicySimulation/{data}" cuentan con la
simulación de una persistencia de datos que permite registrar pólizas y consultarlas sin contar con la base
de datos, sólo con fines de prueba (la información no quedará guardada una vez cierre la ejecución de la 
aplicación).

====================
Insumos
====================

Para los endpoints de registro POST se requiere la siguiente estructura JSON en el cuerpo de la solicitud:

{
  "policyNumber": "POL-12345",
  "customerName": "Juan Pérez",
  "customerId": "ID-1234567890",
  "customerBirth": "1990-05-15T14:30:00Z",
  "policyStartDate": "2023-10-01T09:00:00Z",
  "policyEndDate": "2024-10-01T09:00:00Z",
  "coverages": ["Coverage1", "Coverage2", "Coverage3"],
  "maxPolicyAmount": 50000.0,
  "planName": "Plan A",
  "customerCity": "Medellín",
  "customerAddress": "Dirección de pruebas",
  "vehiclePlate": "ABC-123",
  "vehicleModel": "Modelo de Auto",
  "inspection": true
}
Al ejecutar la aplicación, en la ventana de SWAGGER encontrará el modelo de datos para estos consumos.