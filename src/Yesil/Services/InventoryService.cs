using Yesil.Models;

namespace Yesil.Services;

public class InventoryService
{
    private readonly ObservableCollection<BesinEnvanterOgeleri> _envanter = new();
    private readonly ObservableCollection<AlisverisOgeleri> _alisveris = new();

    public ObservableCollection<BesinEnvanterOgeleri> Envanter => _envanter;
    public ObservableCollection<AlisverisOgeleri> AlisverisListesi => _alisveris;

    public void AddInventoryItem(BesinEnvanterOgeleri item) => _envanter.Add(item);
    public void AddShoppingItem(AlisverisOgeleri item) => _alisveris.Add(item);
}
