
var conn = new Mongo("localhost:6001");
var db = conn.getDB("holyangels");

//NOTE: Use db.collection.save(...) ensures inserts on new or updates on existing

// Page Models for Views/Home
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af00", "Name": "Home", "PageTitle": "Holy Angels - Home", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af01", "Name": "About", "PageTitle": "Holy Angels - About Us", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af02", "Name": "Contact", "PageTitle": "Holy Angels - Contact", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af03", "Name": "History", "PageTitle": "Holy Angels - History", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af04", "Name": "Mission", "PageTitle": "Holy Angels - Mission", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af05", "Name": "Mural", "PageTitle": "Holy Angels - Mural", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af06", "Name": "Privacy", "PageTitle": "Holy Angels - Privacy Policy", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af07", "Name": "Terms", "PageTitle": "Holy Angels - Terms of Use", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af08", "Name": "Christianity", "PageTitle": "Holy Angels - Christianity", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af09", "Name": "Ministries", "PageTitle": "Holy Angels - Ministries", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af0a", "Name": "Articles", "PageTitle": "Holy Angels - Arcticles", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af0b", "Name": "Events", "PageTitle": "Holy Angels - Calendar of Events", "SubTitle": "", "MetaKeywords": "", "MetaDescription": "", "MetaSubject": "", "AccessSettings": ["None"]});

db.pagemodel.createIndex({"Name": "text"});

// Application Roles
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af70", "Name": "Basic" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af71", "Name": "Admin" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af72", "Name": "Publisher" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af73", "Name": "Approver" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af74", "Name": "Published" });

// Application Categories  with discriminator
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af75", _t: "MinistryCategoryModel", "Name": "Catechesis", "Description": "Oral instruction of the Catholic Church doctrine or faith.", "Created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af76", _t: "MinistryCategoryModel", "Name": "Technology", "Description": "", "Created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af77", _t: "MinistryCategoryModel", "Name": "Youth", "Description": "", "Created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af78", _t: "MinistryCategoryModel", "Name": "Women", "Description": "", "Created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af79", _t: "MinistryCategoryModel", "Name": "Men", "Description": "", "Created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af7a", _t: "MinistryCategoryModel", "Name": "Music", "Description": "", "Created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af7b", _t: "MinistryCategoryModel", "Name": "Service", "Description": "", "Created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af7c", _t: "MinistryCategoryModel", "Name": "Evangelization", "Description": "", "Created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af7d", _t: "MinistryCategoryModel", "Name": "Health & Wellness", "Description": "", "Created": new Date()});

// Application Quotes
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af80", "Description": "I am the Alpha and the Omega, says the Lord God, who is, who was, and who is to come, the Almighty.", "Source": "Revelation 1:8"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af81", "Description": "You are worthy, our Lord and God, to receive glory and honour and power, for you made the whole universe; by your will, when it did not exist, it was Created.", "Source": "Revelation 4:11"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af82", "Description": "Father, may your name be held holy, your kingdom come; give us each day our daily bread, and forgive us or sins, for we ourselves forgive each one who is in debt to us. And do not put us to the test.", "Source": "Luke 11:1"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af83", "Description": "Rejoice, you who enjoy God''s favor!..Look! You are to conceive in your womb and bear a son, and you must name him Jesus. He will be great and will be called Son of the Most High", "Source": "Luke 1:39"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af84", "Description": "May God Bless You and Keep You. May God''s Perpetual Light Shine Upon You. In the Name of the Father, Son, And Holy Spirit.", "Source": "Holy Angels Church"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af85", "Description": "Why this uproar among the nations, this impotent muttering of the peoples? Kings on earth take up position, princes plot together against the Lord and his Anointed.", "Source": "Acts 4:37"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af86", "Description": "..the Lord took some bread, and after he had given thanks, he broke it, and he said 'This is my body, which is for you, do this in remembrance of me.' And in the same way, with the cup after supper, saying, This cup is the new covenant in my blood. Whenever you drink it, do this as a memorial of me. Whenever you eat this bread, then and drink this cup, you are proclaiming the Lord's death until he comes. Therefore anyone who eats the bread or drinks the cup of the Lord unworthily is answerable for the body and blood of the Lord.", "Source": "Corinthians 11:27"});

// Application Ministries
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af87", "Name": "Baptism", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af88", "Name": "Holy Communion", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af89", "Name": "Confirmation", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8a", "Name": "Weddings", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8b", "Name": "Children''s Ministry of the Word", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8c", "Name": "Vacation Bible School", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8d", "Name": "Holy Angels''s Angels - Youth Choir", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8e", "Name": "Blessed Sacrament Society", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8f", "Name": "Ladies Volunteers", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af90", "Name": "Ladies of St. Peter Claver", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af91", "Name": "Red Hat Society", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af92", "Name": "Men''s Coalition", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af93", "Name": "Knights of St. Peter Claver", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af94", "Name": "Holy Angels Eucharistic Ensemble", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af95", "Name": "Holy Name Society", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af96", "Name": "Bereavement", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af97", "Name": "Ushers and Greets", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af98", "Name": "HIV/AIDS Ministry", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af99", "Name": "Healthy Side Chats", "Description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af9a", "Name": "Technology Ministry", "Description": ""});

db.eventmodel.save({"_id" : "59b7ff1d4e66df250654a0ba", "Title": "Independance Day", "Description": "Day United States of America declare soverign rule of itself", "Location": "13 colonies on east coast", "Speakers": ["George Washington", "John Adams", "Benjermen Franklin", "Thomas Jefferson"], "TimeStamps": {"StartDate": new Date("04-07-2017"), "StartTime": null, "EndDate": null, "EndTime": null}});
db.eventmodel.save({"_id" : "59b7ff1d4e66df250654a0bb", "Title": "Return to office", "Description": "Karega return to work after an extended vacation aboard", "Location": "Flexible/Remote", "Speakers": ["All States","PCSC", "Agile", "Scrum"], "TimeStamps": {"StartDate": new Date("10-01-2017"), "StartTime": null, "EndDate": null, "EndTime": null}});