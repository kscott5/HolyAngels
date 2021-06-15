function HolyAngels() {
	if(!this instanceof HolyAngels) {
		return new HolyAngels();
	}

    this.HtmlForm = window.document.forms[0];

    this.author = "Karega Scott";
    this.Version = "1.0.0";
    this.UnsecuredHostBaseUrl = "http://" + document.location.host;
    this.SecuredHostBaseUrl = "https://" + document.location.host;
    this.ActualHostBaseUrl = document.location.protocol + "//" + document.location.host;

	return this;
}

HolyAngels.prototype.initEventCalendar = () => {
	var objThis = this;
	
	var el = document.querySelector('#calendar');
	var calendar = new FullCalendar.Calendar(el, {
		plugins: ['dayGrid'],
		defaultView: 'dayGridMonth'
    	header: {
        	left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        editable: false,
      }); // fullcalendar

	calendar.render();
 }; // initEventCalendar

var HA = {};
document.addEventListener('DOMContentLoaded', () => {
	HA = new HolyAngels();
});

