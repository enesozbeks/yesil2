using Yesil.Models;
using Yesil.Services;

namespace Yesil.ViewModels;

public class CommunityViewModel : BaseViewModel
{
    private readonly CommunityService _communityService;

    public ObservableCollection<ToplulukGirdisi> Girdiler { get; }

    public CommunityViewModel(CommunityService communityService)
    {
        _communityService = communityService;
        _communityService.SeedDemoEntries();
        Girdiler = _communityService.GetEntries();
    }
}
