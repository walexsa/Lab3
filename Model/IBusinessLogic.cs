using System.Collections.ObjectModel;

namespace Lab3.Model;

public interface IBusinessLogic
{
    public ObservableCollection<Airport> Airports { get; }
    
    public AirportAdditionError AddAirport(String id, String city, String dateVisited, String rating);
    public AirportDeletionError DeleteAirport(Airport airport);
    public AirportEditError EditAirport(String id, String city, String dateVisited, String rating);
    public int CountAirports();
}
