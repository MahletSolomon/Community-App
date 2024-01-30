using MainProject.Services;

namespace WpfApp1.Commands;

public class JoinCommunityCommand:CommandBase
{
    private JoinCommunityService _joinCommunityService;

    public JoinCommunityCommand(JoinCommunityService joinCommunityService)
    {
        _joinCommunityService = joinCommunityService;
    }
    public override void Execute(object parameter)
    {
        _joinCommunityService.Execute();
    }
}