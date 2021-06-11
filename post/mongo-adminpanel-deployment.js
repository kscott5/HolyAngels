
var conn = new Mongo("localhost:27017");
var db = conn.getDB("holyangels");

//NOTE: Use db.collection.save(...) ensures inserts on new or updates on existing

// Page Models for Views/Home
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0aa00", "Name": "Admin-Dashboard", "PageTitle": "Holy Angels - Admin Dashboard", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["Admin", "Publisher", "Approver"]});

// Application Roles
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af71", "Name": "Admin" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af72", "Name": "Publisher" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af73", "Name": "Approver" });

db.eventmodel.save({"_id" : "59b7ff1d4e66df250654a0ba", "Title": "Independance Day", "Description": "Day United States of America declare soverign rule of itself", "Location": "13 colonies on east coast", "Speakers": ["George Washington", "John Adams", "Benjermen Franklin", "Thomas Jefferson"], "TimeStamps": {"StartDate": new Date("04-07-2017"), "StartTime": null, "EndDate": null, "EndTime": null}});
db.eventmodel.save({"_id" : "59b7ff1d4e66df250654a0bb", "Title": "Return to office", "Description": "Karega return to work after an extended vacation aboard", "Location": "Flexible/Remote", "Speakers": ["All States","PCSC", "Agile", "Scrum"], "TimeStamps": {"StartDate": new Date("10-01-2017"), "StartTime": null, "EndDate": null, "EndTime": null}});
