Public MustInherit Class PEffect
    'PEffect are applied as a result of using a potion
    Public MustOverride Sub apply(ByRef p As Player)

    Public Overridable Function getEffectDesc()
        Return "Unknown effect"
    End Function
End Class
