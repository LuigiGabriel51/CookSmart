//using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.Content;

namespace CookSmart
{
    public class CalendarService
    {
        private Context context;
        public CalendarService()
        {
            context = Android.App.Application.Context;
        }
        private long GetDefaultCalendarId()
        {
            string[] projection = { CalendarContract.Calendars.InterfaceConsts.Id };
            var uri = CalendarContract.Calendars.ContentUri;
            string selection = $"{CalendarContract.Calendars.InterfaceConsts.Visible} = 1 AND {CalendarContract.Calendars.InterfaceConsts.IsPrimary} = 1";
            ICursor cursor = context.ContentResolver.Query(uri, projection, selection, null, null);

            long calendarId = -1;

            if (cursor != null && cursor.MoveToFirst())
            {
                calendarId = cursor.GetLong(0);
                cursor.Close();
            }

            return calendarId;
            
        }

        public long InserirEvento(string titulo, string descricao, DateTime dataInicio, DateTime dataFim)
        {
            long calendarId = GetDefaultCalendarId();
            if (calendarId == -1)
            {
                // Não foi possível obter o ID do calendário padrão
                return -1;
            }

            ContentValues values = new ContentValues();
            values.Put(CalendarContract.Events.InterfaceConsts.CalendarId, calendarId);
            values.Put(CalendarContract.Events.InterfaceConsts.Title, titulo);
            values.Put(CalendarContract.Events.InterfaceConsts.Description, descricao);
            values.Put(CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMillis(dataInicio));
            values.Put(CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMillis(dataFim));
            values.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, Java.Util.TimeZone.Default.ID);

            var uri = context.ContentResolver.Insert(CalendarContract.Events.ContentUri, values);

            long eventId = long.Parse(uri.LastPathSegment);

            return eventId;
        }

        private long GetDateTimeMillis(DateTime dateTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(dateTime.ToUniversalTime() - epoch).TotalMilliseconds;
        }
    }
}