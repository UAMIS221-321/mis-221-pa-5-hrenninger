using mis_221_pa_5_hrenninger;

string title = "TRAIN LIKE A CHAMPION";
string[] options = {"*Manage Trainers", "^View Trainers", "^Add Trainer", "^Update Trainer", "^Delete Trainer", "*Manage Listing", "@View Listings", "@Add Listing", "@Update Listing", "@Delete Listing", "*Manage Bookings", "$Book a Session", "$View Bookings", "$Update Booking", "$Delete Booking", "*Reports", "*^Customer Reports", "^^Sessions by Customer", "^^All Sessions by Customer", "*^Financial Reports", "@@Historical Revenue Report", "*^Trainer Reports","$$Top Trainers", "Example Workouts", "View Saved Reports", "Recycle Bin", "Exit"};
ArrowKeyMenu mainMenu = new ArrowKeyMenu(title, options);
int index = mainMenu.Run(); //run arrow key menu and retrieve index
while (index != 26){
    Route(index, mainMenu);
    index = mainMenu.Run();
}

//Main menu route
static void Route(int index, ArrowKeyMenu mainMenu) {
    if(index == 0){
        mainMenu.ToggleTrainerDropDown();
    }
    else if(index ==1 || index == 2 ||index ==3 ||index ==4){
        TrainerRoute(index);
    }
    else if(index == 5){
        mainMenu.ToggleListingDropDown();
    }
    else if(index == 6||index == 7||index == 8 || index ==9){
        ListingsRoute(index);
    }
    else if(index == 10){
        mainMenu.ToggleBookingDropDown();
    }
    else if(index ==11||index==12||index==13||index==14){
        BookingsRoute(index);
    }
    else if(index==15){
        mainMenu.ToggleReportDropDown();
    }
    else if(index ==16){
        mainMenu.ToggleReportCustDropDown();
    }
    else if(index ==17){
        SessionByCustomer();
    }
    else if(index == 18){
        SortAllSessions();
    }
    else if(index ==19){
        mainMenu.ToggleFinancialReports();
    }
    else if(index ==20){
        RevenueReport();
    }
    else if(index ==21){
        mainMenu.ToggleTrainerReports();
    }
    else if(index ==22){
        TopTrainers();
    }
    else if(index==23){
        Workout();
    }
    else if(index ==24){
        SavedReports();
    }
    else if(index == 25){
        RecycleBin();
    }
}

//manage trainers menu route
static void TrainerRoute(int userChoice) {
    Trainer[] user = new Trainer[100];
    TrainerUtility utility = new TrainerUtility(user);
    TrainerReport report = new TrainerReport(user);
    utility.GetAllTrainersFromFile();
    if(userChoice ==1){
        Console.WriteLine("");
        report.PrintAllTrainers();
        Console.WriteLine("\nPress ENTER to continue...");
        Console.ReadKey();
    }
    else if (userChoice == 2) {
        utility.AddTrainer();
    }
    else if (userChoice == 3){
        Console.Clear();
        report.PrintAllTrainers();
        //trainer.GetAllUsersFromFile();
        utility.UpdateTrainer();
    }
    else if(userChoice == 4){
        Console.Clear();
        report.PrintAllTrainers();
        utility.DeleteTrainer();

    }
}

static void ListingsRoute(int userChoice){
    Listing[] listing = new Listing[100];
    ListingUtility utility = new ListingUtility(listing);
    ListingReport report = new ListingReport(listing);
    utility.GetAllListingsFromFile();
    if (userChoice == 6) {
        Console.WriteLine("");
        report.PrintAllListings();
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadKey();
    }
    else if (userChoice == 7){
        utility.AddListing();
    }
    else if(userChoice == 8){
        Console.Clear();
        report.PrintAllListings();
        utility.UpdateListing();
        
    }
    else if (userChoice == 9){
        Console.Clear();
        report.PrintAllListings();
        utility.DeleteListing();
    } 
}

static void BookingsRoute(int userChoice){
    Listing[] listings = new Listing[100];
    ListingUtility listutility = new ListingUtility(listings);
    listutility.GetAllListingsFromFile();
    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings, listings);
    utility.GetAllBookingsFromFile();
    if (userChoice == 11) {
        utility.BookListing();
    }
    else if (userChoice == 12){
        BookingReport report = new BookingReport(bookings);
        report.PrintAllBookings();
    
    }
    else if (userChoice == 13){
        
    } 
    else if(userChoice ==14){

    }
}
static void Reports(){

}
static void SessionByCustomer(){
    Booking[] bookings = LoadBookings();
    Reports report = new Reports(bookings);
    report.SearchByEmail();
}

static void SortAllSessions(){
    Booking[] bookings = LoadBookings();
    Reports report = new Reports(bookings);
    report.SortByCustomer();
    
}
static Booking[] LoadBookings(){
    Listing[] listings = new Listing[100];
    ListingUtility listutility = new ListingUtility(listings);
    listutility.GetAllListingsFromFile();
    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings, listings);
    utility.GetAllBookingsFromFile();
    return bookings;
}

static void RevenueReport(){
    Booking[] bookings = LoadBookings();
    Reports report = new Reports(bookings);
    report.HistoricalRevReport();
}

static void TopTrainers(){

}
static void Workout(){

}
static void SavedReports(){
    DisplayFiles();
}
static void DisplayFiles(){
    Console.Clear();
    Console.WriteLine("FILES:");
    foreach(var currentFile in Directory.EnumerateFiles("C:\\Users\\hrenn\\Stuff\\mis221\\mis-221-pa-5-hrenninger\\", "*.txt")){
        int remove = "C:\\Users\\hrenn\\Stuff\\mis221\\mis-221-pa-5-hrenninger\\".Count();
        string file = currentFile.Remove(0,remove);
        if(file != "input.txt"&&file!= "deleted.txt"&&file!="listings.txt"&&file!="times.txt"&&file!="trainers.txt"&&file!="transactions.txt"){
            Console.WriteLine($"\t{file}");
        }
    }
    Console.WriteLine("Please enter the file name of the report you would like to view, or press Q to quit");
    string userChoice = Console.ReadLine();
    if(userChoice == "Q"){
        return;
    }
    else{
        ReportUtility utility = new ReportUtility();
        utility.ReadFile(userChoice);
    }
}
static void RecycleBin(){
    string title= "Please choose the recycle bin you would like to view:";
    string[] options = {"trainers", "listings","bookings"};
    
}


