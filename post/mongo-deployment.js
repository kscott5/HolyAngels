
var conn = new Mongo("localhost:6001");
var db = conn.getDB("holyangels");

db.roles.save({_id: 1, "name": "Basic" });
db.roles.save({_id: 2, "name": "Admin" });
db.roles.save({_id: 3, "name": "Publisher" });
db.roles.save({_id: 4, "name": "Approver" });
db.roles.save({_id: 5, "name": "Published" });

db.categories.save({_id: 1, "name": "Catechesis", "description": "Oral instruction of the Catholic Church doctrine or faith.", "created": new Date()});
db.categories.save({_id: 2, "name": "Technology", "description": "", "created": new Date()});
db.categories.save({_id: 3, "name": "Youth", "description": "", "created": new Date()});
db.categories.save({_id: 4, "name": "Women", "description": "", "created": new Date()});
db.categories.save({_id: 5, "name": "Men", "description": "", "created": new Date()});
db.categories.save({_id: 6, "name": "Music", "description": "", "created": new Date()});
db.categories.save({_id: 7, "name": "Service", "description": "", "created": new Date()});
db.categories.save({_id: 8, "name": "Evangelization", "description": "", "created": new Date()});
db.categories.save({_id: 9, "name": "Health & Wellness", "description": "", "created": new Date()});

db.quotes.save({_id: 1, "description": "I am the Alpha and the Omega, says the Lord God, who is, who was, and who is to come, the Almighty.", "source": "Revelation 1:8"});
db.quotes.save({_id: 2, "description": "You are worthy, our Lord and God, to receive glory and honour and power, for you made the whole universe; by your will, when it did not exist, it was created.", "source": "Revelation 4:11"});
db.quotes.save({_id: 3, "description": "Father, may your name be held holy, your kingdom come; give us each day our daily bread, and forgive us or sins, for we ourselves forgive each one who is in debt to us. And do not put us to the test.", "source": "Luke 11:1"});
db.quotes.save({_id: 4, "description": "Rejoice, you who enjoy God''s favor!...Look! You are to conceive in your womb and bear a son, and you must name him Jesus. He will be great and will be called Son of the Most High", "source": "Luke 1:39"});
db.quotes.save({_id: 5, "description": "May God Bless You and Keep You. May God''s Perpetual Light Shine Upon You. In the Name of the Father, Son, And Holy Spirit.", "source": "Holy Angels Church"});
db.quotes.save({_id: 6, "description": "Why this uproar among the nations, this impotent muttering of the peoples? Kings on earth take up position, princes plot together against the Lord and his Anointed.", "source": "Acts 4:37"});
db.quotes.save({_id: 7, "description": "...the Lord took some bread, and after he had given thanks, he broke it, and he said", "name": "'This is my body, which is for you, do this in remembrance of me.'' And in the same way, with the cup after supper, saying, This cup is the new covenant in my blood. Whenever you drink it, do this as a memorial of me. Whenever you eat this bread, then and drink this cup, you are proclaiming the Lord''s death until he comes. Therefore anyone who eats the bread or drinks the cup of the Lord unworthily is answerable for the body and blood of the Lord.", "source": "Corinthians 11:27"});


db.ministries.save({_id: 1, "name": "Baptism", "description": ""});
db.ministries.save({_id: 2, "name": "Holy Communion", "description": ""});
db.ministries.save({_id: 3, "name": "Confirmation", "description": ""});
db.ministries.save({_id: 4, "name": "Weddings", "description": ""});
db.ministries.save({_id: 5, "name": "Children''s Ministry of the Word", "description": ""});
db.ministries.save({_id: 6, "name": "Vacation Bible School", "description": ""});
db.ministries.save({_id: 7, "name": "Holy Angels''s Angels - Youth Choir", "description": ""});
db.ministries.save({_id: 8, "name": "Blessed Sacrament Society", "description": ""});
db.ministries.save({_id: 9, "name": "Ladies Volunteers", "description": ""});
db.ministries.save({_id: 10, "name": "Ladies of St. Peter Claver", "description": ""});
db.ministries.save({_id: 11, "name": "Red Hat Society", "description": ""});
db.ministries.save({_id: 12, "name": "Men''s Coalition", "description": ""});
db.ministries.save({_id: 13, "name": "Knights of St. Peter Claver", "description": ""});
db.ministries.save({_id: 14, "name": "Holy Angels Eucharistic Ensemble", "description": ""});
db.ministries.save({_id: 15, "name": "Holy Name Society", "description": ""});
db.ministries.save({_id: 16, "name": "Bereavement", "description": ""});
db.ministries.save({_id: 17, "name": "Ushers and Greets", "description": ""});
db.ministries.save({_id: 18, "name": "HIV/AIDS Ministry", "description": ""});
db.ministries.save({_id: 19, "name": "Healthy Side Chats", "description": ""});
db.ministries.save({_id: 20, "name": "Technology Ministry", "description": ""});

