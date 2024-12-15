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
        //update

let editContact (phoneNumber: string) (newName: string) (newEmail: string) =
    if contacts.ContainsKey(phoneNumber) then
        contacts.[phoneNumber] <- { Name = newName; PhoneNumber = phoneNumber; Email = newEmail }
        MessageBox.Show($"Contact updated successfully!") |> ignore
    else
        MessageBox.Show("Contact not found!") |> ignore
        
let deleteContact (phoneNumber: string) =
    if contacts.Remove(phoneNumber) then
        MessageBox.Show($"Contact deleted successfully!") |> ignore
    else
        MessageBox.Show("Contact not found!") |> ignore
