namespace Lab3;

using Model;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = MauiProgram.BusinessLogic;
    }

    /// <summary>
    /// Adds an airport to the database and displays it to the screen.
    /// </summary>
    /// <param name="sender"> button pressed </param>
    /// <param name="e"> event </param>
    void AddAirport_Clicked(System.Object sender, System.EventArgs e)
    {
        AirportAdditionError result = MauiProgram.BusinessLogic.AddAirport(IdENT.Text, CityENT.Text, DateVisitedENT.Text, RatingENT.Text);

        if (result != AirportAdditionError.NoError)
        {
            DisplayAlert("Oops!", result.ToString(), "OK");
            return;
        }

        // clear the users input from each line
        IdENT.Text = ""; 
        CityENT.Text = "";
        DateVisitedENT.Text = "";
        RatingENT.Text = "";
    }

    /// <summary>
    /// Deletes an airport from the database and the screen (only if the airport is selected first)
    /// </summary>
    /// <param name="sender"> button pressed </param>
    /// <param name="e"> event </param>
    void DeleteAirport_Clicked(System.Object sender, System.EventArgs e)
    {
        Airport currentAirport = CV.SelectedItem as Airport;
        AirportDeletionError result = MauiProgram.BusinessLogic.DeleteAirport(currentAirport);
        if (result != AirportDeletionError.NoError)
        {
            DisplayAlert("Oops!", result.ToString(), "OK");
            return;
        }
    }

    /// <summary>
    /// Edits an airport in the database and on the screen
    /// </summary>
    /// <param name="sender"> button pressed </param>
    /// <param name="e"> event </param>
    void EditAirport_Clicked(System.Object sender, System.EventArgs e)
    {
        Airport currentAirport = CV.SelectedItem as Airport;
        AirportEditError result;
        if (currentAirport == null) // handle if the user didn't select an airport, but included all of the data to edit
        {
            result = MauiProgram.BusinessLogic.EditAirport(IdENT.Text, CityENT.Text, DateVisitedENT.Text, RatingENT.Text);
        } 
        else
        {
            result = MauiProgram.BusinessLogic.EditAirport(currentAirport.Id, CityENT.Text, DateVisitedENT.Text, RatingENT.Text);
        }

        if (result != AirportEditError.NoError)
        {
            DisplayAlert("Oops!", result.ToString(), "OK");
            return;
        }

        IdENT.Text = "";
        CityENT.Text = "";
        DateVisitedENT.Text = "";
        RatingENT.Text = "";
    }

    /// <summary>
    /// Displays user statistics to the screen on button click
    /// </summary>
    /// <param name="sender"> button pressed </param>
    /// <param name="e"> event </param>
    void CalculateStatistics_Clicked(System.Object sender, System.EventArgs e)
    {
        int numAirportsVisited = MauiProgram.BusinessLogic.CountAirports();
        String statistics;
        if (numAirportsVisited == -1) // if-else block creates statistics in a string
        {
            DisplayAlert("Oops!", "Error while counting Airports", "OK");
            return;
        }
        else if (numAirportsVisited == 1)
        {
            statistics = "1 airport visited; 41 airports remaining until achieving Bronze";
        }
        else if (numAirportsVisited >= 0 && numAirportsVisited < 42)
        {
            statistics = numAirportsVisited + " airports visited; " + (42 - numAirportsVisited) + " airports remaining until achieving Bronze";
        }
        else if (numAirportsVisited >= 42 && numAirportsVisited > 84)
        {
            statistics = numAirportsVisited + " airports visited; " + (84 - numAirportsVisited) + " airports remaining until achieving Silver";
        }
        else if (numAirportsVisited >= 84 && numAirportsVisited < 125)
        {
            statistics = numAirportsVisited + " airports visited; " + (125 - numAirportsVisited) + " airports remaining until achieving Gold";
        }
        else
        {
            statistics = numAirportsVisited + " airports visited; congrats on achieving Gold";
        }
        DisplayAlert("Statistics:", statistics, "OK");
        return;
    }
}