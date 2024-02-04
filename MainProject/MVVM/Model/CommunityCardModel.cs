using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MainProject.MVVM.Model;

public class CommunityCardModel:INotifyPropertyChanged
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string OwnerID { get; set; }
    public string OwnerPictureUrl { get; set; }
    public string OwnerName { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public string MemberTotal { get; set; }
    private int postTotal;

    public int PostTotal
    {
        get => postTotal;
        set
        {
            postTotal = value;
            OnPropertyChanged();
        } }
    public DateTime CreatedDate { get; set; }
    public ObservableCollection<PostModel> Posts { get; set; }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}