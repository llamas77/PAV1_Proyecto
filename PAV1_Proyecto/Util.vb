Imports System

Public Class Util
    Public Shared Function UnixTimeStampToDateTime(ByVal unixTimeStamp As Double) As DateTime
        'Unix timestamp is seconds past epoch
        Dim dtDateTime As New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime()
        Return dtDateTime
    End Function

    Public Shared Function DateTimeToUnixTimestamp(ByRef dateTime As DateTime) As Double
        Return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
           New DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds
    End Function
End Class
