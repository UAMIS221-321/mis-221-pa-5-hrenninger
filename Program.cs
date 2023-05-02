using mis_221_pa_5_hrenninger;
string emptytitle = "";
string[] preMenu = {"WELCOME TO TRAIN LIKE A CHAMPION!!!","*Many features today are navigated through the arrow keys and pressing ENTER*", "Lets practice! Press ENTER on any option to continue!"};
ArrowKeyOptions test = new ArrowKeyOptions(emptytitle, preMenu);
int blank = test.Run();
string title = @"
 TRAIN LIKE A CHAMPION
          __o
        _'\<,_
      \(_)/_(_)/ o
   _   \      / <|\
 ___\o_ \    /  _\
 ~~~~~~  \  /
";
string[] options = {"*Manage Trainers", "^View Trainers", "^Add Trainer", "^Update Trainer", "^Delete Trainer", "*Manage Listing", "@View Listings", "@Add Listing", "@Update Listing", "@Delete Listing", "*Manage Bookings", "$Book a Session", "$View Bookings", "$Update Booking", "$Delete Booking", "*Reports", "*^Customer Reports", "^^Sessions by Customer", "^^All Sessions by Customer", "*^Financial Reports", "@@Historical Revenue Report", "*^Trainer Reports","$$Top Trainers", "TLAC Cares", "View Saved Reports", "Recycle Bin", "Exit"};
ArrowKeyMenu mainMenu = new ArrowKeyMenu(title, options);
int index = mainMenu.Run(); //run arrow key menu and retrieve index
while (index != 26){  //while user choice is not exit, run the main menu
    Route(index, mainMenu);
    index = mainMenu.Run();
}

//Main menu route
static void Route(int index, ArrowKeyMenu mainMenu) {
    if(index == 0){
        mainMenu.ToggleTrainerDropDown(); //option 1 toggles the drop down for trainer functions
    }
    else if(index >=1 &&index <=4){
        TrainerRoute(index);
    }
    else if(index == 5){
        mainMenu.ToggleListingDropDown();//toggle the drop down for listing functions
    }
    else if(index >= 6&& index <=9){
        ListingsRoute(index);
    }
    else if(index == 10){
        mainMenu.ToggleBookingDropDown();  //toggle the drop down for booking functions
    }
    else if(index >=11&&index<=14){
        BookingsRoute(index);
    }
    else if(index==15){
        mainMenu.ToggleReportDropDown();
    }
    else if(index ==16){
        mainMenu.ToggleReportCustDropDown();
    }
    else if(index == 17|| index == 18 ||index ==20 ||index ==22){
        ReportRoute(index);
    }
    else if(index ==19){
        mainMenu.ToggleFinancialReports();
    }
    else if(index ==21){
        mainMenu.ToggleTrainerReports();
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
static void TrainerRoute(int userChoice) {  //route user choice for trainer functions
    Trainer[] user = new Trainer[100];   //initialize Trainer object array called user
    TrainerUtility utility = new TrainerUtility(user);  //initialize TrainerUtility object and pass in user 
    TrainerReport report = new TrainerReport(user); 
    utility.GetAllTrainersFromFile(); //load trainers from file into object array
    if(userChoice ==1){
        report.PrintAllTrainers();
        PauseAction();
    }
    else if (userChoice == 2) {
        utility.AddTrainer();
    }
    else if (userChoice == 3){
        report.PrintAllTrainers();
        utility.UpdateTrainer();
    }
    else if(userChoice == 4){
        report.PrintAllTrainers();
        utility.DeleteTrainer();
    }
}

static void ListingsRoute(int userChoice){
    Listing[] listing = new Listing[100];
    ListingUtility utility = new ListingUtility(listing);
    ListingReport report = new ListingReport(listing);
    utility.GetAllListingsFromFile(); //load listings into listings array
    if (userChoice == 6) {
        report.PrintAllListings();
        PauseAction();
    }
    else if (userChoice == 7){
        utility.AddListing();
    }
    else if(userChoice == 8){
        report.PrintAllListings();
        utility.UpdateListing();
    }
    else if (userChoice == 9){
        report.PrintAllListings();
        utility.DeleteListing();
    } 
}

static void BookingsRoute(int userChoice){
    Listing[] listings = new Listing[100]; //loading booking
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
        PauseAction();
    }
    else if (userChoice == 13){
        utility.UpdateBooking();
    } 
    else if(userChoice ==14){
        utility.DeleteBooking();
    }
}
static void ReportRoute(int index){
    Booking[] bookings = LoadBookings();
    Reports report = new Reports(bookings);
    if (index == 17){
        Console.Clear();
        report.SearchByEmail();
    }
    else if(index == 18){
        Console.Clear();
        report.SortByCustomer();
    }
    else if(index == 20){
        Console.Clear();
        report.HistoricalRevReport();
    }
    else if(index == 22){
        Console.Clear();
        report.TopTrainers();
    }
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

static void Workout(){ 
    TLACCares run = new TLACCares();
    run.TLACCaresActivity();
}
static void SavedReports(){ 
    DisplayFiles();
}
static void DisplayFiles(){
    Console.Clear();
    Console.WriteLine("FILES:"); //only display files that contain reports
    foreach(var currentFile in Directory.EnumerateFiles("C:\\Users\\hrenn\\Stuff\\mis221\\mis-221-pa-5-hrenninger\\", "*.txt")){
        int remove = "C:\\Users\\hrenn\\Stuff\\mis221\\mis-221-pa-5-hrenninger\\".Count();
        string file = currentFile.Remove(0,remove);
        if(file != "input.txt"&&file!= "deletedtrainers.txt"&&file!="listings.txt"&&file!="times.txt"&&file!="trainers.txt"&&file!="transactions.txt"&&file!="deletedlistings.txt"&&file!="deletedbookings.txt"){
            Console.WriteLine($"\t{file}");
        }
    }
    Console.WriteLine("Please enter the file name of the report you would like to view, or press Q to quit");
    string userChoice = Console.ReadLine(); //enter report type
    if(userChoice.ToUpper() == "Q"){
        return;
    }
    else{
        ReportUtility utility = new ReportUtility();
        utility.ReadFile(userChoice);
    }
    PauseAction();
}
static void RecycleBin(){
    ReportUtility utility = new ReportUtility();//recylce and restore option
    string title= "Please choose the recycle bin you would like to view:";
    string[] options = {"Trainers", "Listings","Bookings", "Exit"};
    ArrowKeyOptions recycle = new ArrowKeyOptions(title, options);
    int index = recycle.Run();
    while(index!=3){
        switch(index){
            case 0:
                utility.ReadFile("deletedtrainers.txt");
                utility.RestoreFile("trainers");
            break;
            case 1:
                utility.ReadFile("deletedlistings.txt");
                utility.RestoreFile("listings");
            break;
            case 2:
                utility.ReadFile("deletedbookings.txt");
                utility.RestoreFile("bookings");
            break;
        }
        index = recycle.Run();
    }
}

static void PauseAction(){
    Console.WriteLine("\nPress ENTER to continue...");
    Console.ReadKey();
}