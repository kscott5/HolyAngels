
var conn = new Mongo("localhost:6001");
var db = conn.getDB("holyangels");

//NOTE: Use db.collection.save(...) ensures inserts on new or updates on existing

// Page Models for Views/Home
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af00", "name": "Home", "pagetitle": "Holy Angels - Home", "subtitle": "", "metakeywords": "", "metadescription": "", "metasubject": "", "accesssettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af01", "name": "About", "pagetitle": "Holy Angels - About Us", "subtitle": "", "metakeywords": "", "metadescription": "", "metasubject": "", "accesssettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af02", "name": "Contact", "pagetitle": "Holy Angels - Contact", "subtitle": "", "metakeywords": "", "metadescription": "", "metasubject": "", "accesssettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af03", "name": "History", "pagetitle": "Holy Angels - History", "subtitle": "", "metakeywords": "", "metadescription": "", "metasubject": "", "accesssettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af04", "name": "Mission", "pagetitle": "Holy Angels - Mission", "subtitle": "", "metakeywords": "", "metadescription": "", "metasubject": "", "accesssettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af05", "name": "Mural", "pagetitle": "Holy Angels - Mural", "subtitle": "", "metakeywords": "", "metadescription": "", "metasubject": "", "accesssettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af06", "name": "Privacy", "pagetitle": "Holy Angels - Privacy Policy", "subtitle": "", "metakeywords": "", "metadescription": "", "metasubject": "", "accesssettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af07", "name": "Terms", "pagetitle": "Holy Angels - Terms of Use", "subtitle": "", "metakeywords": "", "metadescription": "", "metasubject": "", "accesssettings": ["None"]});
db.pagemodel.save({"_id": "59af6ef3f21f2e6b34c0af08", "name": "Christianity", "pagetitle": "Holy Angels - Christianity", "subtitle": "", "metakeywords": "", "metadescription": "", "metasubject": "", "accesssettings": ["None"]});

db.pagemodel.createIndex({"name": "text"});

// Application Roles
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af70", "name": "Basic" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af71", "name": "Admin" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af72", "name": "Publisher" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af73", "name": "Approver" });
db.rolemodel.save({"_id": "59af6ef3f21f2e6b34c0af74", "name": "Published" });

// Application Categories  with discriminator
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af75", _t: "MinistryCategoryModel", "name": "Catechesis", "description": "Oral instruction of the Catholic Church doctrine or faith.", "created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af76", _t: "MinistryCategoryModel", "name": "Technology", "description": "", "created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af77", _t: "MinistryCategoryModel", "name": "Youth", "description": "", "created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af78", _t: "MinistryCategoryModel", "name": "Women", "description": "", "created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af79", _t: "MinistryCategoryModel", "name": "Men", "description": "", "created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af7a", _t: "MinistryCategoryModel", "name": "Music", "description": "", "created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af7b", _t: "MinistryCategoryModel", "name": "Service", "description": "", "created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af7c", _t: "MinistryCategoryModel", "name": "Evangelization", "description": "", "created": new Date()});
db.catorymodel.save({"_id": "59af6ef3f21f2e6b34c0af7d", _t: "MinistryCategoryModel", "name": "Health & Wellness", "description": "", "created": new Date()});

// Application Quotes
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af80", "description": "I am the Alpha and the Omega, says the Lord God, who is, who was, and who is to come, the Almighty.", "source": "Revelation 1:8"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af81", "description": "You are worthy, our Lord and God, to receive glory and honour and power, for you made the whole universe; by your will, when it did not exist, it was created.", "source": "Revelation 4:11"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af82", "description": "Father, may your name be held holy, your kingdom come; give us each day our daily bread, and forgive us or sins, for we ourselves forgive each one who is in debt to us. And do not put us to the test.", "source": "Luke 11:1"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af83", "description": "Rejoice, you who enjoy God''s favor!..Look! You are to conceive in your womb and bear a son, and you must name him Jesus. He will be great and will be called Son of the Most High", "source": "Luke 1:39"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af84", "description": "May God Bless You and Keep You. May God''s Perpetual Light Shine Upon You. In the Name of the Father, Son, And Holy Spirit.", "source": "Holy Angels Church"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af85", "description": "Why this uproar among the nations, this impotent muttering of the peoples? Kings on earth take up position, princes plot together against the Lord and his Anointed.", "source": "Acts 4:37"});
db.quotemodel.save({"_id": "59af6ef3f21f2e6b34c0af86", "description": "..the Lord took some bread, and after he had given thanks, he broke it, and he said", "name": "'This is my body, which is for you, do this in remembrance of me.'' And in the same way, with the cup after supper, saying, This cup is the new covenant in my blood. Whenever you drink it, do this as a memorial of me. Whenever you eat this bread, then and drink this cup, you are proclaiming the Lord''s death until he comes. Therefore anyone who eats the bread or drinks the cup of the Lord unworthily is answerable for the body and blood of the Lord.", "source": "Corinthians 11:27"});

// Application Ministries
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af87", "name": "Baptism", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af88", "name": "Holy Communion", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af89", "name": "Confirmation", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8a", "name": "Weddings", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8b", "name": "Children''s Ministry of the Word", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8c", "name": "Vacation Bible School", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8d", "name": "Holy Angels''s Angels - Youth Choir", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8e", "name": "Blessed Sacrament Society", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af8f", "name": "Ladies Volunteers", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af90", "name": "Ladies of St. Peter Claver", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af91", "name": "Red Hat Society", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af92", "name": "Men''s Coalition", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af93", "name": "Knights of St. Peter Claver", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af94", "name": "Holy Angels Eucharistic Ensemble", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af95", "name": "Holy Name Society", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af96", "name": "Bereavement", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af97", "name": "Ushers and Greets", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af98", "name": "HIV/AIDS Ministry", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af99", "name": "Healthy Side Chats", "description": ""});
db.ministrymodel.save({"_id": "59af6ef3f21f2e6b34c0af9a", "name": "Technology Ministry", "description": ""});

