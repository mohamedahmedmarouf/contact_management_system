open System
open System.Windows.Forms
open System.Collections.Generic


type Contact = {
    Name: string
    PhoneNumber: string
    Email: string
}


[<STAThread>]
do

   
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)

    
    let contacts = new Dictionary<string, Contact>()

    
    let addContact (name: string) (phoneNumber: string) (email: string) =
        if not (contacts.ContainsKey(phoneNumber)) then
            contacts.[phoneNumber] <- { Name = name; PhoneNumber = phoneNumber; Email = email }
            MessageBox.Show($"Contact '{name}' added successfully!") |> ignore
        else
            MessageBox.Show("Contact already exists!") |> ignore
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

    let searchContact (phoneNumber: string) =
        if contacts.ContainsKey(phoneNumber) then
            let contact = contacts.[phoneNumber]
            MessageBox.Show($"Name: {contact.Name}\nPhone: {contact.PhoneNumber}\nEmail: {contact.Email}") |> ignore
        else
            MessageBox.Show("Contact not found!") |> ignore

    
    let form = new Form(Text = "Contact Management System", Width = 400, Height = 400)

    let nameLabel = new Label(Text = "Name:", Top = 20, Left = 20)
    let nameTextBox = new TextBox(Top = 20, Left = 100, Width = 200)

    let phoneLabel = new Label(Text = "Phone:", Top = 60, Left = 20)
    let phoneTextBox = new TextBox(Top = 60, Left = 100, Width = 200)

    let emailLabel = new Label(Text = "Email:", Top = 100, Left = 20)
    let emailTextBox = new TextBox(Top = 100, Left = 100, Width = 200)

    let addButton = new Button(Text = "Add", Top = 140, Left = 20)
    addButton.Click.Add(fun _ -> addContact nameTextBox.Text phoneTextBox.Text emailTextBox.Text)

    let editButton = new Button(Text = "Edit", Top = 140, Left = 100)
    editButton.Click.Add(fun _ -> editContact phoneTextBox.Text nameTextBox.Text emailTextBox.Text)

    let deleteButton = new Button(Text = "Delete", Top = 140, Left = 180)
    deleteButton.Click.Add(fun _ -> deleteContact phoneTextBox.Text)

    let searchButton = new Button(Text = "Search", Top = 140, Left = 260)
    searchButton.Click.Add(fun _ -> searchContact phoneTextBox.Text)

    
    form.Controls.AddRange([| nameLabel; nameTextBox; phoneLabel; phoneTextBox; emailLabel; emailTextBox; addButton; editButton; deleteButton; searchButton |])

  
    Application.Run(form)
