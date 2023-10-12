using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.Mobile.TestSpace
{
    internal class TestClass
    {
    }
}

/*
 
 
 
 public class Contact { 
    public string FirstName { 
        get; 
        set; 
    }        
    public string LastName { 
        get; 
        set; 
    } 
    //... 
} 

public class ContactsContext : DbContext { 
    public DbSet<Model.Contact> Contacts { get; set; } 
    public ContactsContext() { 
        //Initiates SQLite on iOS 
        SQLitePCL.Batteries_V2.Init(); 
        this.Database.EnsureCreated(); 
    } 
    //Sets up the location of the SQLite database on the physical device 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, App.DbFileName); 
        optionsBuilder.UseSqlite($"Filename={dbPath}"); 
        base.OnConfiguring(optionsBuilder); 
    } 
} 


CopyWorkingFilesToAppData(DbFileName).Wait(); 

//...
public async Task<string> CopyWorkingFilesToAppData(string fileName) { 
    string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName); 
    if (File.Exists(targetFile)) 
        return targetFile; 
    using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName); 
    using FileStream outputStream = File.OpenWrite(targetFile); 
    fileStream.CopyTo(outputStream); 
    return targetFile; 
} 



Load data from the database and pass it to the Contacts collection:

async void LoadData() {
    IsRefreshing = true;
    using ContactsContext context = new ContactsContext();
    await context.Contacts.LoadAsync();
    Contacts = new ObservableCollection<Model.Contact>(context.Contacts);
    Companies = new ObservableCollection<string>(Contacts.Select(c => c.Company));
    IsRefreshing = false;
}


Bind the CollectionView control to the Contacts collection:

<dxcv:DXCollectionView ItemsSource="{Binding Contacts}" ...>
Bind ViewModel to Create, Read, and Update Views
Bind UI controls on detail views to appropriate data properties and commands.

The CollectionView control passes the view model to next-level views: new item form, edit form, and detail view. This view model contains commands and item properties. The following code snippet binds the item's FirstName property to Label.Text:

<Label Text="{Binding Item.FirstName}" .../>
The following code snippet binds a ToolbarItem control to EditCommand:

<ToolbarItem Command="{Binding EditCommand}" .../>
Invoke Read and Create Views
Call the ShowDetailForm command to display the detail view:

<dxco:SimpleButton Command="{Binding Source={x:Reference collectionView}, Path=Commands.ShowDetailForm}" .../>
Place a SimpleButton control above the CollectionView control in the Grid panel to implement a Floating Action Button (FAB). Users can click this button to add a new item to the collection.

<Grid>
    <dxcv:DXCollectionView>
        ...
    </dxcv:DXCollectionView>
    <dxco:SimpleButton Command="{Binding Source={x:Reference collectionView}, Path=Commands.ShowDetailNewItemForm}" Text="+" VerticalOptions="End" HorizontalOptions="End" ... />
</Grid>
Customize Create, Read, and Update Views
To replace auto-generated CRUD Views, specify DetailFormTemplate, DetailEditFormTemplate, and DetailNewItemFormTemplate properties:

<dxcv:DXCollectionView ...
                        DetailFormTemplate="{DataTemplate local:DetailInfoPage}"
                        DetailEditFormTemplate="{DataTemplate local:ContactEditingPage}"
                        DetailNewItemFormTemplate="{DataTemplate local:ContactEditingPage}">
Files to Review:

DetailInfoPage.xaml
ContactEditingPage.xaml
Use the DataFormView control to build the edit view. The view's editors post their changes when you call the Commit method. This allows you to discard changes if the user goes back and cancels the edit operation.

Validate User Input
Handle the DataFormView.ValidateProperty event to validate user input on the editor's level:

void dataForm_ValidateProperty(object sender, DataFormPropertyValidationEventArgs e) {
    if (e.PropertyName == "Email" && e.NewValue != null) {
        MailAddress res;
        if (!MailAddress.TryCreate((string)e.NewValue, out res)) {
            e.HasError = true;
            e.ErrorText = "Invalid email";
        }
    }
}
You can also apply validation attributes the data object. The DataFormView control validates its editors accordingly. The following code sample marks the FirstName property with the Required attribute (the marked property cannot be empty):

public class Contact : BindableBase {
[Required(ErrorMessage = "First Name cannot be empty")]
public string FirstName {
    get;
    set;
}
Additional Information: Handle a Remote Database Connection Error
The changed data may not be saved to the database due to a connection error or another database constraint. To handle these errors, subscribe to the DXCollectionView.ValidateAndSave event. This event uses the unit of work pattern that creates a DBContext for each database operation (edit, add, or delete):

async void ValidateAndSave(ValidateItemEventArgs e) {
    ContactsContext context;
    var changedContact = (Model.Contact)e.Item;
    if (e.DataChangeType == DataChangeType.Edit) {
        context = (ContactsContext)e.Context;
    }
    else
        context = new ContactsContext();
    try {
        if (e.DataChangeType == DataChangeType.Add) {
            context.Contacts.Add(changedContact);
        }
        else if (e.DataChangeType == DataChangeType.Edit) {
            context.Contacts.Update(changedContact);
        }
        else if (e.DataChangeType == DataChangeType.Delete) {
            var issue = new Model.Contact() { ID = changedContact.ID };
            context.Entry(issue).State = EntityState.Deleted;
        }
        context.SaveChanges();
    }
    catch (Exception ex) {
        e.IsValid = false;
        await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
    }
}
In the code snippet above, the edit operation uses the ContactsContext DBContext that is created when item editing starts:

void CreateDetailFormViewModel(CreateDetailFormViewModelEventArgs e) {
    if (e.DetailFormType == DetailFormType.Edit) {
        ContactsContext contactsContext = new ContactsContext();
        Model.Contact editedContact = (Model.Contact)contactsContext.Find(typeof(Model.Contact), ((Model.Contact)e.Item).ID);
        e.Result = new DetailEditFormViewModel(editedContact, isNew: false, context: contactsContext);
    }
}
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 */
