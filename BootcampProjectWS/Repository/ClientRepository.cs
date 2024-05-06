using BootcampProjectWS.DBModels;
using BootcampProjectWS.Models;

namespace BootcampProjectWS.Repository
{
    public class ClientRepository
    {
        public string? InsertClient(BootcampprojectContext context, InsertClientModelRequest Model)
        {
            Client client = new Client
            {
                Firstname = Model.Firstname,
                Lastname = Model.Lastname,
                Identification = Model.Identification,
                Phonenumber = Model.Phonenumber,
                Address = Model.Address,
                Referenceaddress = Model.Referenceaddress,
                Email = Model.Email
            };

            context.Clients.Add(client);

            try
            {
                context.SaveChanges();
                return null;
            }
            catch(Exception ex)
            {
                return ex.InnerException.ToString();
            }
            
        }

        //nueva funcion
        public string? UpdateClient(BootcampprojectContext context, InsertClientModelRequest Model, int idClient)
        {
            Client clientFind = context.Clients.Where(x => x.Clientid == idClient).FirstOrDefault();

            if (clientFind != null)
            {
                clientFind.Firstname = Model.Firstname;
                clientFind.Lastname = Model.Lastname;
                clientFind.Identification = Model.Identification;
                clientFind.Phonenumber = Model.Phonenumber;
                clientFind.Address = Model.Address;
                clientFind.Referenceaddress = Model.Referenceaddress;
                clientFind.Email = Model.Email;

                try
                {
                    context.SaveChanges();
                    return null;
                }
                catch(Exception ex)
                {
                    return ex.InnerException.ToString();
                }
                
            }
            else
            {
                return "No se encontró cliente.";
            }

        }

    }
}
