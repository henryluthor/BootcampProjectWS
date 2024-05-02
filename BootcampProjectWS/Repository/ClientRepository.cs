﻿using BootcampProjectWS.DBModels;
using BootcampProjectWS.Models;

namespace BootcampProjectWS.Repository
{
    public class ClientRepository
    {
        public bool InsertClient(BootcampprojectContext context, InsertClientModelRequest Model)
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
            context.SaveChanges();
            return true;
        }

        //nueva funcion
        public bool UpdateClient(BootcampprojectContext context, InsertClientModelRequest Model, int idClient)
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

                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}