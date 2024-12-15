open System
open System.Windows.Forms
open System.Collections.Generic

type Contact = {
    Name: string
    PhoneNumber: string
    Email: string
}

let contacts = new Dictionary<string, Contact>()

let addContact (name: string) (phoneNumber: string) (email: string) =
    if not (contacts.ContainsKey(phoneNumber)) then
        contacts.[phoneNumber] <- { Name = name; PhoneNumber = phoneNumber; Email = email }
        MessageBox.Show($"Contact '{name}' added successfully!") |> ignore
    else
        MessageBox.Show("Contact already exists!") |> ignore