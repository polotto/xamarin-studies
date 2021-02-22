# xamarin-studies
 xamarin studies

## Xamarin course
### Resources
- code gist: https://gist.github.com/kristijankralj/8418524e337ea5117869419e28df9658
- xamarin goodlooking UI: https://github.com/jsuarezruiz/xamarin-forms-goodlooking-UI
- full criptollet code: https://github.com/kristijankralj/cryptollet
- list of localizations: https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-lcid/a9eac961-e77d-41a6-90a5-ce1a8b0cdb9c
- xamarin localization: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/localization/text?pivots=macos

### Netget
- autofac depency injection library: https://autofac.org/ (https://www.nuget.org/packages/Autofac/)
- charts library: https://github.com/dotnet-ad/Microcharts
- newtonsoft: https://www.nuget.org/packages/Newtonsoft.Json/
- sqlite: https://www.nuget.org/packages/sqlite-net-pcl/1.8.0-beta 

### api
- crypto currency api: https://www.coingecko.com/en/api/
- mock api: https://example-data.draftbit.com/

### xamarin snippets
Visual Studio / Preferences / Text Editor / Code Snippets

- shortcut: xfprop
- group: C#
- Description: xamarin forms property
- Mine: text/x-csharp
- is expandable template
- template text:
```c#
private $type$ _$name$;
public $type$ $name$
{
    get => _$name$;
    set { SetProperty(ref _$name$, value); }
}
```

- shortcut: xfcmd
- group: C#
- Description: new xamarin forms command
- Mine: text/x-csharp
- is expandable template
- template text:
```c#
public ICommand $name$Command { get => new Command(async() => await $name$()); }
private async Task $name$()
{
    
}
```

- shortcut: param
- group: C#
- Description: new private parameter
- Mine: text/x-csharp
- is expandable template
- template text:
```c#
private $type$ _$name$;
```

- shortcut: mth
- group: C#
- Description: create private method
- Mine: text/x-csharp
- is expandable template
- template text:
```c#
private $type$ $name$()
{
    
}
```