using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Helpers;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Globalization;

[BotAuthentication]
public class MessagesController : ApiController
{
    List<Activity> listActivity = new List<Activity>();


    /// <summary>
    /// POST: api/Messages
    /// Receive a message from a user and reply to it
    /// </summary>
    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {

        try
        {
            

            if (activity.Type == ActivityTypes.Message)
            {
                MicrosoftAppCredentials.TrustServiceUrl(@"https://facebook.botframework.com", DateTime.MaxValue);
                if (activity.Text == "Video")
                {
                    Helpers.Helpers.userDataStruct userStruct = new Helpers.Helpers.userDataStruct();
                    userStruct.userName = activity.From.Name;
                    userStruct.userId = activity.From.Id;
                    userStruct.botName = activity.Recipient.Name;
                    userStruct.botId = activity.Recipient.Id;
                    userStruct.ServiceUrl = activity.ServiceUrl;

                    AddToLog("UserName: " + userStruct.userName + " User Id: " + userStruct.userId + " BOtId: " + userStruct.botId + " BotName: " + userStruct.botName + " url: " + userStruct.ServiceUrl);
                  //  AddUser(userStruct.userName, userStruct.userId, userStruct.botName, userStruct.botId, userStruct.ServiceUrl, 1);

                    Helpers.Helpers.listaAdresow.Add(userStruct);
                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var userAccount = new ChannelAccount(name: activity.From.Name, id: activity.From.Id);
                    var botAccount = new ChannelAccount(name: activity.Recipient.Name, id: activity.Recipient.Id);
                    connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);
                    IMessageActivity message = Activity.CreateMessageActivity();
                    message.ChannelData = JObject.FromObject(new
                    {
                        notification_type = "REGULAR",
                        //buttons = new dynamic[]
                        // {
                        //     new
                        //     {
                        //    type ="postback",
                        //    title="Tytul",
                        //    vslue = "tytul",
                        //    payload="DEVELOPER_DEFINED_PAYLOAD"
                        //     }
                        // },
                        quick_replies = new dynamic[]
                               {
                                //new
                                //{
                                //    content_type = "text",
                                //    title = "Aktualności",
                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                                //    image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                //},
                                new
                                {
                                    content_type = "text",
                                    title = "PlusLiga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                              //      image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                new
                                                                {
                                    content_type = "text",
                                    title = "ORLEN Liga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                                 //   image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                },
                                                                new
                                {
                                    content_type = "text",
                                    title = "Video",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                               //     image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                //},
                                //new
                                //{
                                //    content_type = "text",
                                //    title = "Red",

                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_RED",
                                //}
                               }
                    });
                    message.From = botAccount;
                    message.Recipient = userAccount;
                    message.Conversation = new ConversationAccount(id: conversationId.Id);
                    message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    List<IGrouping<string, string>> hrefList = new List<IGrouping<string, string>>();
                    message.Attachments = GetCardsAttachmentsVideo(ref hrefList, true);

                    await connector.Conversations.SendToConversationAsync((Activity)message);

                }
                else if(activity.Text== "PlusLiga")
                {
                    Helpers.Helpers.userDataStruct userStruct = new Helpers.Helpers.userDataStruct();
                    userStruct.userName = activity.From.Name;
                    userStruct.userId = activity.From.Id;
                    userStruct.botName = activity.Recipient.Name;
                    userStruct.botId = activity.Recipient.Id;
                    userStruct.ServiceUrl = activity.ServiceUrl;

                  //  AddToLog("UserName: " + userStruct.userName + " User Id: " + userStruct.userId + " BOtId: " + userStruct.botId + " BotName: " + userStruct.botName + " url: " + userStruct.ServiceUrl);
                   // AddUser(userStruct.userName, userStruct.userId, userStruct.botName, userStruct.botId, userStruct.ServiceUrl, 1);

                    Helpers.Helpers.listaAdresow.Add(userStruct);
                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var userAccount = new ChannelAccount(name: activity.From.Name, id: activity.From.Id);
                    var botAccount = new ChannelAccount(name: activity.Recipient.Name, id: activity.Recipient.Id);
                    connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);
                    IMessageActivity message = Activity.CreateMessageActivity();
                    message.ChannelData = JObject.FromObject(new
                    {
                        notification_type = "REGULAR",


                        buttons = new dynamic[]
                        {
                            new
                            {
                                type ="web_url",
                                url = "https://petersfancyapparel.com/classic_white_tshirt",
                                title ="Wyniki",
                                webview_height_ratio = "compact"
                            }
                        },

                        quick_replies = new dynamic[]
                               {
                                //new
                                //{oh
                                //    content_type = "text",
                                //    title = "Aktualności",
                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                                //    image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                //},
                                new
                                {
                                    content_type = "text",
                                    title = "PlusLiga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                             //       image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                new
                                                                {
                                    content_type = "text",
                                    title = "ORLEN Liga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                                //    image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                },
                                                                new
                                {
                                    content_type = "text",
                                    title = "Video",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                            //        image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                //},
                                //new
                                //{
                                //    content_type = "text",
                                //    title = "Red",

                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_RED",
                                //}
                               }
                    });


                    message.From = botAccount;
                    message.Recipient = userAccount;
                    message.Conversation = new ConversationAccount(id: conversationId.Id);
                    message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    List<IGrouping<string, string>> hrefList = new List<IGrouping<string, string>>();

                    message.Attachments = GetCardsAttachments(ref hrefList, true);

                    await connector.Conversations.SendToConversationAsync((Activity)message);

                }
                else if (activity.Text=="ORLEN Liga")
                {
                    Helpers.Helpers.userDataStruct userStruct = new Helpers.Helpers.userDataStruct();
                    userStruct.userName = activity.From.Name;
                    userStruct.userId = activity.From.Id;
                    userStruct.botName = activity.Recipient.Name;
                    userStruct.botId = activity.Recipient.Id;
                    userStruct.ServiceUrl = activity.ServiceUrl;

                    //AddToLog("UserName: " + userStruct.userName + " User Id: " + userStruct.userId + " BOtId: " + userStruct.botId + " BotName: " + userStruct.botName + " url: " + userStruct.ServiceUrl);
                   // AddUser(userStruct.userName, userStruct.userId, userStruct.botName, userStruct.botId, userStruct.ServiceUrl, 1);

                    Helpers.Helpers.listaAdresow.Add(userStruct);
                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var userAccount = new ChannelAccount(name: activity.From.Name, id: activity.From.Id);
                    var botAccount = new ChannelAccount(name: activity.Recipient.Name, id: activity.Recipient.Id);
                    connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);
                    IMessageActivity message = Activity.CreateMessageActivity();
                    message.ChannelData = JObject.FromObject(new
                    {
                        notification_type = "REGULAR",


                        buttons = new dynamic[]
                        {
                            new
                            {
                                type ="web_url",
                                url = "https://petersfancyapparel.com/classic_white_tshirt",
                                title ="Wyniki",
                                webview_height_ratio = "compact"
                            }
                        },

                        quick_replies = new dynamic[]
                               {
                                //new
                                //{
                                //    content_type = "text",
                                //    title = "Aktualności",
                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                                //    image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                //},
                                new
                                {
                                    content_type = "text",
                                    title = "PlusLiga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                                 //   image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                                                new
                                {
                                    content_type = "text",
                                    title = "ORLEN Liga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                                 //   image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                },
                                                                                                new
                                {
                                    content_type = "text",
                                    title = "Video",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                               //     image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                //},
                                //new
                                //{
                                //    content_type = "text",
                                //    title = "Red",

                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_RED",
                                //}
                               }
                    });


                    message.From = botAccount;
                    message.Recipient = userAccount;
                    message.Conversation = new ConversationAccount(id: conversationId.Id);
                    message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    List<IGrouping<string, string>> hrefList = new List<IGrouping<string, string>>();

                    message.Attachments = GetCardsAttachmentsOrlenLiga(ref hrefList, true);

                    await connector.Conversations.SendToConversationAsync((Activity)message);
                }
                else if (activity.Text == "USER_DEFINED_PAYLOAD" || activity.Text == "Aktualności")
                {
                    Helpers.Helpers.userDataStruct userStruct = new Helpers.Helpers.userDataStruct();
                    userStruct.userName = activity.From.Name;
                    userStruct.userId = activity.From.Id;
                    userStruct.botName = activity.Recipient.Name;
                    userStruct.botId = activity.Recipient.Id;
                    userStruct.ServiceUrl = activity.ServiceUrl;

                    //AddToLog("UserName: " + userStruct.userName + " User Id: " + userStruct.userId + " BOtId: " + userStruct.botId + " BotName: " + userStruct.botName + " url: " + userStruct.ServiceUrl);
                    AddUser(userStruct.userName, userStruct.userId, userStruct.botName, userStruct.botId, userStruct.ServiceUrl, 1);

                    Helpers.Helpers.listaAdresow.Add(userStruct);
                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var userAccount = new ChannelAccount(name: activity.From.Name, id: activity.From.Id);
                    var botAccount = new ChannelAccount(name: activity.Recipient.Name, id: activity.Recipient.Id);
                    connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);
                    IMessageActivity message = Activity.CreateMessageActivity();

                    message.ChannelData = JObject.FromObject(new
                    {
                        notification_type = "REGULAR",
                        //buttons = new dynamic[]
                        // {
                        //     new
                        //     {
                        //    type ="postback",
                        //    title="Tytul",
                        //    vslue = "tytul",
                        //    payload="DEVELOPER_DEFINED_PAYLOAD"
                        //     }
                        // },
                        quick_replies = new dynamic[]
                               {
                                //new
                                //{
                                //    content_type = "text",
                                //    title = "Aktualności",
                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                                //    image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                //},
                                new
                                {
                                    content_type = "text",
                                    title = "PlusLiga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                               //     image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                new
                                                                {
                                    content_type = "text",
                                    title = "ORLEN Liga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                              //      image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                },                                new
                                {
                                    content_type = "text",
                                    title = "Video",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                             //       image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                //},
                                //new
                                //{
                                //    content_type = "text",
                                //    title = "Red",

                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_RED",
                                //}
                               }
                    });

                    
                    message.From = botAccount;
                    message.Recipient = userAccount;
                    message.Conversation = new ConversationAccount(id: conversationId.Id);
                    message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    List<IGrouping<string, string>> hrefList = new List<IGrouping<string, string>>();
                    message.Attachments = GetCardsAttachments(ref hrefList, true);

                    await connector.Conversations.SendToConversationAsync((Activity)message);



                    //var signinCard = new SigninCard()
                    //{
                    //    //  Text = "Wybierz pozycje zamówienia",
                    //    Buttons = new List<CardAction> {
                    //     new CardAction()
                    //        {
                    //            Value = "Najbliższa kolejka",
                    //            Type = "postBack",
                    //            Title = "Najbliższa kolejka",

                    //          //  Image = "https://cdn1.iconfinder.com/data/icons/logotypes/32/square-facebook-128.png"
                    //        },
                    //     new CardAction()
                    //        {
                    //            Value = "Wyniki",
                    //            Type = "postBack",
                    //            Title = "Wyniki",
                    //         //   Image = "http://images.dailytech.com/nimage/G_is_For_Google_New_Logo_Thumb.png"
                    //        }
                    //    }
                    //};
                    //message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    //message.Attachments = new List<Attachment> {
                    //    signinCard.ToAttachment()
                    //};

                    //message.Attachments = null;
                    //message.Attachments.Add(new Attachment()
                    //{
                    //    ContentUrl = "https://upload.wikimedia.org/wikipedia/en/a/a6/Bender_Rodriguez.png",
                    //    ContentType = "image/png",
                    //    Name = "Bender_Rodriguez.png"
                    //});


                    //await connector.Conversations.SendToConversationAsync((Activity)message);
                }
                else
                {
                    Helpers.Helpers.userDataStruct userStruct = new Helpers.Helpers.userDataStruct();
                    userStruct.userName = activity.From.Name;
                    userStruct.userId = activity.From.Id;
                    userStruct.botName = activity.Recipient.Name;
                    userStruct.botId = activity.Recipient.Id;
                    userStruct.ServiceUrl = activity.ServiceUrl;

                    //AddToLog("UserName: " + userStruct.userName + " User Id: " + userStruct.userId + " BOtId: " + userStruct.botId + " BotName: " + userStruct.botName + " url: " + userStruct.ServiceUrl);
                    //AddUser(userStruct.userName, userStruct.userId, userStruct.botName, userStruct.botId, userStruct.ServiceUrl, 1);

                    Helpers.Helpers.listaAdresow.Add(userStruct);
                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var userAccount = new ChannelAccount(name: activity.From.Name, id: activity.From.Id);
                    var botAccount = new ChannelAccount(name: activity.Recipient.Name, id: activity.Recipient.Id);
                    connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);
                    IMessageActivity message = Activity.CreateMessageActivity();

                    message.ChannelData = JObject.FromObject(new
                    {
                        notification_type = "REGULAR",
                        //buttons = new dynamic[]
                        // {
                        //     new
                        //     {
                        //    type ="postback",
                        //    title="Tytul",
                        //    vslue = "tytul",
                        //    payload="DEVELOPER_DEFINED_PAYLOAD"
                        //     }
                        // },
                        quick_replies = new dynamic[]
                               {
                                //new
                                //{
                                //    content_type = "text",
                                //    title = "Aktualności",
                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                                //    image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                //},
                                new
                                {
                                    content_type = "text",
                                    title = "PlusLiga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                               //     image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                new
                                                                {
                                    content_type = "text",
                                    title = "ORLEN Liga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                              //      image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                },                                new
                                {
                                    content_type = "text",
                                    title = "Video",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                             //       image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                //},
                                //new
                                //{
                                //    content_type = "text",
                                //    title = "Red",

                                //    payload = "DEFINED_PAYLOAD_FOR_PICKING_RED",
                                //}
                               }
                    });


                    message.From = botAccount;
                    message.Recipient = userAccount;
                    message.Conversation = new ConversationAccount(id: conversationId.Id);
                    message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    List<IGrouping<string, string>> hrefList = new List<IGrouping<string, string>>();
                    message.Text = "Wybierz";
                   // message.Attachments = GetCardsAttachments(ref hrefList, true);

                    await connector.Conversations.SendToConversationAsync((Activity)message);

                }
            }

            else
            {
                HandleSystemMessage(activity);
            }
        }
        catch (Exception ex)
        {
            AddToLog("Wysylanie wiadomosci: " + ex.ToString());
        }
        var response = Request.CreateResponse(HttpStatusCode.OK);
        return response;
    }

    public async static void SendThreadMessage()
    {

        try
        {
            if (DateTime.UtcNow.Hour == 17 &&  (DateTime.UtcNow.Minute > 0 && DateTime.UtcNow.Minute <= 3))
            {

                AddToLog("Wywołanie metody SendThreadMessage");

                List<IGrouping<string, string>> hrefList = new List<IGrouping<string, string>>();
                List<IGrouping<string, string>> hrefList2 = new List<IGrouping<string, string>>();
                List<IGrouping<string, string>> hreflist3 = new List<IGrouping<string, string>>();
                var items = GetCardsAttachments(ref hrefList);
                hreflist3 = hrefList;
                var items2 = GetCardsAttachmentsOrlenLiga(ref hrefList2);

                var items3 = new List<Attachment>();

                foreach (var item in items)
                {
                    if (items3.Count() < 4)
                    {
                        items3.Add(item);
                    }
                }

                if (items3.Count() == 0)
                {
                    for (int i = 0; i < items2.Count(); i++)
                    {
                        if (i < 2)
                        {
                            items3.Add(items2[i]);
                        }
                    }
                }
                else if (items3.Count() == 1)
                {
                    for (int i = 0; i < items2.Count(); i++)
                    {
                        if (i < 2)
                        {
                            items3.Add(items2[i]);
                        }
                    }
                }
                else if (items3.Count() == 2)
                {
                    for (int i = 0; i < items2.Count(); i++)
                    {
                        if (i < 2)
                        {
                            items3.Add(items2[i]);
                        }
                    }
                }
                else if (items3.Count() == 3)
                {
                    for (int i = 0; i < items2.Count(); i++)
                    {
                        if (i == 0)
                        {
                            items3[2] = items2[i];
                        }
                        else if (i == 1)
                        {
                            items3.Add(items2[i]);
                        }
                    }
                }
                else if (items3.Count() == 4)
                {
                    for (int i = 0; i < items2.Count(); i++)
                    {
                        if (i == 0)
                        {
                            items3[2] = items2[i];
                        }
                        else if (i == 1)
                        {
                            items3[3] = items2[i];
                        }
                    }
                }

                items = items3;


                string uzytkownik = "";
                Int64 uzytkownikId = 0;
                DataTable dt = GetUser();

                if (items.Count > 0)
                {
                    try
                    {
                        MicrosoftAppCredentials.TrustServiceUrl(@"https://facebook.botframework.com", DateTime.MaxValue);

                        IMessageActivity message = Activity.CreateMessageActivity();
                        message.ChannelData = JObject.FromObject(new
                        {
                            notification_type = "REGULAR",
                            quick_replies = new dynamic[]
                                {
                               new
                                {
                                    content_type = "text",
                                    title = "PlusLiga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                                  //  image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },
                                new
                                                                {
                                    content_type = "text",
                                    title = "ORLEN Liga",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_BLUE",
                                   // image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Blue%20Ball.png"
                                },                                new
                                {
                                    content_type = "text",
                                    title = "Video",
                                    payload = "DEFINED_PAYLOAD_FOR_PICKING_GREEN",
                                   // image_url = "https://cdn3.iconfinder.com/data/icons/developperss/PNG/Green%20Ball.png"
                                },

                                }
                        });

                        message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                        message.Attachments = items;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                var userAccount = new ChannelAccount(name: dt.Rows[i]["UserName"].ToString(), id: dt.Rows[i]["UserId"].ToString());
                                uzytkownik = userAccount.Name;
                                uzytkownikId = Convert.ToInt64(userAccount.Id);
                                var botAccount = new ChannelAccount(name: dt.Rows[i]["BotName"].ToString(), id: dt.Rows[i]["BotId"].ToString());
                                var connector = new ConnectorClient(new Uri(dt.Rows[i]["Url"].ToString()), "0c13722a-e1e0-4876-a1ce-d245404e7eda", "CQcoBVbMwV5XvcYYpqsdJQR");
                                var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);
                                message.From = botAccount;
                                message.Recipient = userAccount;
                                message.Conversation = new ConversationAccount(id: conversationId.Id, isGroup: false);
                                await connector.Conversations.SendToConversationAsync((Activity)message).ConfigureAwait(false);
                            }
                            catch (Exception ex)
                            {
                                AddToLog("Błąd wysyłania wiadomości do: " + uzytkownik + " " + ex.ToString());
                                DeleteUser(uzytkownikId);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        AddToLog("Błąd wysyłania wiadomości do: " + uzytkownik + " " + ex.ToString());
                    }
                    

                    AddWiadomosc(hreflist3);
                    AddWiadomoscOrlen(hrefList2);
                }
            }
        }
        catch (Exception ex)
        {
            AddToLog("Błąd wysłania wiadomosci: " +ex.ToString());
        }
    }

    public static void CallToChildThread()
    {
        try
        {

            Thread.Sleep(5000);
        }

        catch (ThreadAbortException e)
        {
            Console.WriteLine("Thread Abort Exception");
        }
        finally
        {
            Console.WriteLine("Couldn't catch the Thread Exception");
        }
    }

    private Activity HandleSystemMessage(Activity message)
    {
        if (message.Type == ActivityTypes.DeleteUserData)
        {
            DeleteUser(Convert.ToInt64(message.From.Id));
        }
        else if (message.Type == ActivityTypes.ConversationUpdate)
        {
          
        }
        else if (message.Type == ActivityTypes.ContactRelationUpdate)
        {

        }
        else if (message.Type == ActivityTypes.Typing)
        {
            // Handle knowing tha the user is typing
        }
        else if (message.Type == ActivityTypes.Ping)
        {
        }
        else if(message.Type == ActivityTypes.Typing)
        {

        }
        return null;
    }

    public static DataTable GetUser()
    {
        DataTable dt = new DataTable();

        try
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();
            
            cmd.CommandText = "SELECT * FROM [dbo].[User] where flgDeleted=0";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            sqlConnection1.Close();
            return dt;
        }
        catch
        {
            AddToLog("Błąd pobierania użytkowników");
            return null;
        }
    }

    public static DataTable GetWiadomosci()
    {
        DataTable dt = new DataTable();

        try
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM [dbo].[Wiadomosci]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            sqlConnection1.Close();
            return dt;
        }
        catch
        {
            AddToLog("Błąd pobierania wiadomości");
            return null;
        }
    }

    public static DataTable GetWiadomosciOrlen()
    {
        DataTable dt = new DataTable();

        try
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM [dbo].[WiadomosciOrlen]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            sqlConnection1.Close();
            return dt;
        }
        catch
        {
            AddToLog("Błąd pobierania wiadomości Orlen");
            return null;
        }
    }


    public static IList<Attachment> GetCardsAttachments(ref List<IGrouping<string, string>> hrefList, bool newUser=false)
    {
        List<Attachment> list = new List<Attachment>();

        string urlAddress = "http://www.plusliga.pl";
       // string urlAddress = "http://www.orlenliga.pl/";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                        var listTemp2 = new List<System.Linq.IGrouping<string, string>>();

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            if (response.CharacterSet == null)
            {
                readStream = new StreamReader(receiveStream);
            }
            else
            {
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            }

            string data = readStream.ReadToEnd();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(data);

            string matchResultDivId = "owl-carousel-home-slider-2";
            string xpath = String.Format("//div[@id='{0}']/div", matchResultDivId);
            var people = doc.DocumentNode.SelectNodes(xpath).Select(p => p.InnerHtml);
            string text = "";
            foreach (var person in people)
            {
                text += person;
            }

            HtmlDocument doc2 = new HtmlDocument();

            doc2.LoadHtml(text);
            hrefList = doc2.DocumentNode.SelectNodes("//a")
                              .Select(p => p.GetAttributeValue("href", "not found")).Where(p => p.Contains("/news/") || p.Contains("/video/") || p.Contains("/gallery/")||p.Contains("/blog/")).GroupBy(p => p.ToString())
                              .ToList();

            var imgList = doc2.DocumentNode.SelectNodes("//img")
                              .Select(p => p.GetAttributeValue("src", "not found"))
                              .ToList();

            var titleList = doc2.DocumentNode.SelectNodes("//img")
                              .Select(p => p.GetAttributeValue("alt", "not found"))
                              .ToList();

            response.Close();
            readStream.Close();

            int index = 5;

            DataTable dt = GetWiadomosci();

            if (newUser == true)
            {
                index = 5;
                if (dt.Rows.Count == 0)
                {
                    //    AddWiadomosc(hrefList);
                }
            }

            else
            {

                if (dt.Rows.Count > 0)
                {
                    List<int> deleteList = new List<int>();
                    var listTemp = new List<System.Linq.IGrouping<string, string>>();
                    var imageListTemp = new List<string>();
                    var titleListTemp = new List<string>();

                    for (int i = 0; i < hrefList.Count; i++)
                    {
                        if (dt.Rows[dt.Rows.Count - 1]["Wiadomosc1"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc2"].ToString() != hrefList[i].Key &&
                            dt.Rows[dt.Rows.Count - 1]["Wiadomosc3"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc4"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc5"].ToString() != hrefList[i].Key
                           )
                        {
                            listTemp.Add(hrefList[i]);
                            imageListTemp.Add(imgList[i]);
                            titleListTemp.Add(titleList[i]);
                        }
                        listTemp2.Add(hrefList[i]);
                    }
                    hrefList = listTemp;
                    index = hrefList.Count;
                    imgList = imageListTemp;
                    titleList = titleListTemp;
                    //   AddWiadomosc(listTemp2);
                    
                }
                else
                {
                    index = 5;
                    //   AddWiadomosc(hrefList);
                }
            }

            for (int i = 0; i < index; i++)
            {

                string link = "";
                if (hrefList[i].Key.Contains("http"))
                {
                    link = hrefList[i].Key;
                }
                else
                {
                    link = "http://plusliga.pl" + hrefList[i].Key;
                    //link = "http://www.orlenliga.pl/" + hrefList[i].Key;
                }

                if (link.Contains("video"))
                {
                    list.Add(GetHeroCard(
       titleList[i], "", "",
       new CardImage(url: imgList[i]),
       new CardAction(ActionTypes.OpenUrl, "Oglądaj video", value: link),
       new CardAction(ActionTypes.OpenUrl, "Udostępnij", value: "https://www.facebook.com/sharer/sharer.php?u=" + link))
   );
                }
                else if(link.Contains("gallery"))
                {
                    list.Add(GetHeroCard(
     titleList[i], "", "",
     new CardImage(url: imgList[i]),
     new CardAction(ActionTypes.OpenUrl, "Przeglądaj galerie", value: link),
     new CardAction(ActionTypes.OpenUrl, "Udostępnij", value: "https://www.facebook.com/sharer/sharer.php?u=" + link))
 );
                }
                else
                {
                    list.Add(GetHeroCard(
       titleList[i], "", "",
       new CardImage(url: imgList[i]),
       new CardAction(ActionTypes.OpenUrl, "Czytaj więcej", value: link),
       new CardAction(ActionTypes.OpenUrl, "Udostępnij", value: "https://www.facebook.com/sharer/sharer.php?u=" + link))
   );
                }

              //  list.Add(new Microsoft.Bot.Connector.VideoCard(titleList[i], "", "",null)
                }
            
        }
        if (listTemp2.Count > 0)
        {
            hrefList = listTemp2;
        }

        return list;
        //return new List<Attachment>()
        //{
        //    for(int i=0;i<5;i++)
        //    GetHeroCard(
        //        "Azure Storage",
        //        "Massively scalable cloud storage for your applications",
        //        "Store and help protect your data. Get durable, highly available data storage across the globe and pay only for what you use.",
        //        new CardImage(url: "https://acom.azurecomcdn.net/80C57D/cdn/mediahandler/docarticles/dpsmedia-prod/azure.microsoft.com/en-us/documentation/articles/storage-introduction/20160801042915/storage-concepts.png"),
        //        new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/storage/")),
        //  //  GetThumbnailCard(
        //    //    "DocumentDB",
        //    //    "Blazing fast, planet-scale NoSQL",
        //    //    "NoSQL service for highly available, globally distributed apps—take full advantage of SQL and JavaScript over document and key-value data without the hassles of on-premises or virtual machine-based cloud database options.",
        //    //    new CardImage(url: "https://sec.ch9.ms/ch9/29f4/beb4b953-ab91-4a31-b16a-71fb6d6829f4/WhatisAzureDocumentDB_960.jpg"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/documentdb/")),
        //    //GetHeroCard(
        //    //    "Azure Functions",
        //    //    "Process events with serverless code",
        //    //    "Azure Functions is a serverless event driven experience that extends the existing Azure App Service platform. These nano-services can scale based on demand and you pay only for the resources you consume.",
        //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),
        //    //GetThumbnailCard(
        //    //    "Cognitive Services",
        //    //    "Build powerful intelligence into your applications to enable natural and contextual interactions",
        //    //    "Enable natural and contextual interaction with tools that augment users' experiences using the power of machine-based intelligence. Tap into an ever-growing collection of powerful artificial intelligence algorithms for vision, speech, language, and knowledge.",
        //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),

        //};
    }


    public static IList<Attachment> GetCardsAttachmentsOrlenLiga(ref List<IGrouping<string, string>> hrefList, bool newUser = false)
    {
        List<Attachment> list = new List<Attachment>();

       // string urlAddress = "http://www.plusliga.pl";
         string urlAddress = "http://www.orlenliga.pl/";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        var listTemp2 = new List<System.Linq.IGrouping<string, string>>();

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            if (response.CharacterSet == null)
            {
                readStream = new StreamReader(receiveStream);
            }
            else
            {
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            }

            string data = readStream.ReadToEnd();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(data);

            string matchResultDivId = "owl-carousel-home-slider-2";
            string xpath = String.Format("//div[@id='{0}']/div", matchResultDivId);
            var people = doc.DocumentNode.SelectNodes(xpath).Select(p => p.InnerHtml);
            string text = "";
            foreach (var person in people)
            {
                text += person;
            }

            HtmlDocument doc2 = new HtmlDocument();

            doc2.LoadHtml(text);
            hrefList = doc2.DocumentNode.SelectNodes("//a")
                              .Select(p => p.GetAttributeValue("href", "not found")).Where(p => p.Contains("/news/") || p.Contains("/video/") || p.Contains("/gallery/")).GroupBy(p => p.ToString())
                              .ToList();

            var imgList = doc2.DocumentNode.SelectNodes("//img")
                              .Select(p => p.GetAttributeValue("src", "not found"))
                              .ToList();

            var titleList = doc2.DocumentNode.SelectNodes("//img")
                              .Select(p => p.GetAttributeValue("alt", "not found"))
                              .ToList();

            response.Close();
            readStream.Close();

            int index = 5;

            DataTable dt = GetWiadomosciOrlen();

            if (newUser == true)
            {
                index = 5;
                if (dt.Rows.Count == 0)
                {
                    //    AddWiadomosc(hrefList);
                }
            }

            else
            {

                if (dt.Rows.Count > 0)
                {
                    List<int> deleteList = new List<int>();
                    var listTemp = new List<System.Linq.IGrouping<string, string>>();
                    var imageListTemp = new List<string>();
                    var titleListTemp = new List<string>();

                    for (int i = 0; i < hrefList.Count; i++)
                    {
                        if (dt.Rows[dt.Rows.Count - 1]["Wiadomosc1"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc2"].ToString() != hrefList[i].Key &&
                            dt.Rows[dt.Rows.Count - 1]["Wiadomosc3"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc4"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc5"].ToString() != hrefList[i].Key
                            )
                        {
                            listTemp.Add(hrefList[i]);
                            imageListTemp.Add(imgList[i]);
                            titleListTemp.Add(titleList[i]);
                        }
                        listTemp2.Add(hrefList[i]);
                    }
                    hrefList = listTemp;
                    index = hrefList.Count;
                    imgList = imageListTemp;
                    titleList = titleListTemp;
                    //   AddWiadomosc(listTemp2);
                }
                else
                {
                    index = 5;
                    //   AddWiadomosc(hrefList);
                }
            }

            for (int i = 0; i < index; i++)
            {

                string link = "";
                if (hrefList[i].Key.Contains("http"))
                {
                    link = hrefList[i].Key;
                }
                else
                {
                 //   link = "http://plusliga.pl" + hrefList[i].Key;
                    link = "http://www.orlenliga.pl/" + hrefList[i].Key;
                }
                if (link.Contains("video"))
                {
                    list.Add(GetHeroCard(
                     titleList[i], "", "",
                     new CardImage(url: imgList[i]),
                     new CardAction(ActionTypes.OpenUrl, "Oglądaj video", value: link),
                     new CardAction(ActionTypes.OpenUrl, "Udostępnij", value: "https://www.facebook.com/sharer/sharer.php?u=" + link))
                 );
                }
                else if(link.Contains("gallery"))
                {
                    list.Add(GetHeroCard(
                   titleList[i], "", "",
                   new CardImage(url: imgList[i]),
                   new CardAction(ActionTypes.OpenUrl, "Przeglądaj galerie", value: link),
                   new CardAction(ActionTypes.OpenUrl, "Udostępnij", value: "https://www.facebook.com/sharer/sharer.php?u=" + link))
               );
                }
                else
                {
                    list.Add(GetHeroCard(
                     titleList[i], "", "",
                     new CardImage(url: imgList[i]),
                     new CardAction(ActionTypes.OpenUrl, "Czytaj więcej", value: link),
                     new CardAction(ActionTypes.OpenUrl, "Udostępnij", value: "https://www.facebook.com/sharer/sharer.php?u=" + link))
                 );
                }

                  
                //  list.Add(new Microsoft.Bot.Connector.VideoCard(titleList[i], "", "",null)
            }

        }
        if (listTemp2.Count > 0)
        {
            hrefList = listTemp2;
        }
        return list;
        //return new List<Attachment>()
        //{
        //    for(int i=0;i<5;i++)
        //    GetHeroCard(
        //        "Azure Storage",
        //        "Massively scalable cloud storage for your applications",
        //        "Store and help protect your data. Get durable, highly available data storage across the globe and pay only for what you use.",
        //        new CardImage(url: "https://acom.azurecomcdn.net/80C57D/cdn/mediahandler/docarticles/dpsmedia-prod/azure.microsoft.com/en-us/documentation/articles/storage-introduction/20160801042915/storage-concepts.png"),
        //        new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/storage/")),
        //  //  GetThumbnailCard(
        //    //    "DocumentDB",
        //    //    "Blazing fast, planet-scale NoSQL",
        //    //    "NoSQL service for highly available, globally distributed apps—take full advantage of SQL and JavaScript over document and key-value data without the hassles of on-premises or virtual machine-based cloud database options.",
        //    //    new CardImage(url: "https://sec.ch9.ms/ch9/29f4/beb4b953-ab91-4a31-b16a-71fb6d6829f4/WhatisAzureDocumentDB_960.jpg"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/documentdb/")),
        //    //GetHeroCard(
        //    //    "Azure Functions",
        //    //    "Process events with serverless code",
        //    //    "Azure Functions is a serverless event driven experience that extends the existing Azure App Service platform. These nano-services can scale based on demand and you pay only for the resources you consume.",
        //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),
        //    //GetThumbnailCard(
        //    //    "Cognitive Services",
        //    //    "Build powerful intelligence into your applications to enable natural and contextual interactions",
        //    //    "Enable natural and contextual interaction with tools that augment users' experiences using the power of machine-based intelligence. Tap into an ever-growing collection of powerful artificial intelligence algorithms for vision, speech, language, and knowledge.",
        //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),

        //};
    }

    public static IList<Attachment> GetCardsAttachmentsVideo(ref List<IGrouping<string, string>> hrefList, bool newUser = false)
    {
        List<Attachment> list = new List<Attachment>();

        string urlAddress = "http://www.siatkarskaligatv.pl/";
        // string urlAddress = "http://www.orlenliga.pl/";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        var listTemp2 = new List<System.Linq.IGrouping<string, string>>();

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            if (response.CharacterSet == null)
            {
                readStream = new StreamReader(receiveStream);
            }
            else
            {
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            }

            string data = readStream.ReadToEnd();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(data);

            string matchResultDivId = "owl-carousel-home-slider-2";
            string xpath = String.Format("//div[@id='{0}']/div", matchResultDivId);
            var people = doc.DocumentNode.SelectNodes(xpath).Select(p => p.InnerHtml);
            string text = "";
            foreach (var person in people)
            {
                text += person;
            }

            HtmlDocument doc2 = new HtmlDocument();

            doc2.LoadHtml(text);
            hrefList = doc2.DocumentNode.SelectNodes("//a")
                              .Select(p => p.GetAttributeValue("href", "not found")).Where(p => p.Contains("/video/")).GroupBy(p => p.ToString())
                              .ToList();

            for(int i=0;i<hrefList.Count;i++)
            {
                if(hrefList[i].Key.Contains("comments"))
                {
                    hrefList.RemoveAt(i);
                }
            }

            var imgList = doc2.DocumentNode.SelectNodes("//img")
                              .Select(p => p.GetAttributeValue("src", "not found"))
                              .ToList();

            var titleList = doc2.DocumentNode.SelectNodes("//img")
                              .Select(p => p.GetAttributeValue("alt", "not found"))
                              .ToList();

            response.Close();
            readStream.Close();

            int index = 5;

            DataTable dt = GetWiadomosci();

            if (newUser == true)
            {
                index = 5;
                if (dt.Rows.Count == 0)
                {
                    //    AddWiadomosc(hrefList);
                }
            }

            else
            {

                if (dt.Rows.Count > 0)
                {
                    List<int> deleteList = new List<int>();
                    var listTemp = new List<System.Linq.IGrouping<string, string>>();
                    var imageListTemp = new List<string>();
                    var titleListTemp = new List<string>();

                    for (int i = 0; i < hrefList.Count; i++)
                    {
                        if (dt.Rows[dt.Rows.Count - 1]["Wiadomosc1"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc2"].ToString() != hrefList[i].Key &&
                            dt.Rows[dt.Rows.Count - 1]["Wiadomosc3"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc4"].ToString() != hrefList[i].Key
                            )
                        {
                            listTemp.Add(hrefList[i]);
                            imageListTemp.Add(imgList[i]);
                            titleListTemp.Add(titleList[i]);
                        }
                        listTemp2.Add(hrefList[i]);
                    }
                    hrefList = listTemp;
                    index = hrefList.Count;
                    imgList = imageListTemp;
                    titleList = titleListTemp;
                    //   AddWiadomosc(listTemp2);
                }
                else
                {
                    index = 5;
                    //   AddWiadomosc(hrefList);
                }
            }

            for (int i = 0; i < index; i++)
            {

                string link = "";
                if (hrefList[i].Key.Contains("http"))
                {
                    link = hrefList[i].Key;
                }
                else
                {
                    link = "http://www.siatkarskaligatv.pl/" + hrefList[i].Key;
                    //link = "http://www.orlenliga.pl/" + hrefList[i].Key;
                }


                list.Add(GetHeroCard(
                       titleList[i], "", "",
                       new CardImage(url: imgList[i]),
                       new CardAction(ActionTypes.OpenUrl, "Oglądaj video", value: link),
                       new CardAction(ActionTypes.OpenUrl, "Udostępnij", value: "https://www.facebook.com/sharer/sharer.php?u=" + link))
                   );
                //  list.Add(new Microsoft.Bot.Connector.VideoCard(titleList[i], "", "",null)
            }

        }
        if (listTemp2.Count>0)
        {
            hrefList = listTemp2;
        }
        return list;
        //return new List<Attachment>()
        //{
        //    for(int i=0;i<5;i++)
        //    GetHeroCard(
        //        "Azure Storage",
        //        "Massively scalable cloud storage for your applications",
        //        "Store and help protect your data. Get durable, highly available data storage across the globe and pay only for what you use.",
        //        new CardImage(url: "https://acom.azurecomcdn.net/80C57D/cdn/mediahandler/docarticles/dpsmedia-prod/azure.microsoft.com/en-us/documentation/articles/storage-introduction/20160801042915/storage-concepts.png"),
        //        new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/storage/")),
        //  //  GetThumbnailCard(
        //    //    "DocumentDB",
        //    //    "Blazing fast, planet-scale NoSQL",
        //    //    "NoSQL service for highly available, globally distributed apps—take full advantage of SQL and JavaScript over document and key-value data without the hassles of on-premises or virtual machine-based cloud database options.",
        //    //    new CardImage(url: "https://sec.ch9.ms/ch9/29f4/beb4b953-ab91-4a31-b16a-71fb6d6829f4/WhatisAzureDocumentDB_960.jpg"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/documentdb/")),
        //    //GetHeroCard(
        //    //    "Azure Functions",
        //    //    "Process events with serverless code",
        //    //    "Azure Functions is a serverless event driven experience that extends the existing Azure App Service platform. These nano-services can scale based on demand and you pay only for the resources you consume.",
        //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),
        //    //GetThumbnailCard(
        //    //    "Cognitive Services",
        //    //    "Build powerful intelligence into your applications to enable natural and contextual interactions",
        //    //    "Enable natural and contextual interaction with tools that augment users' experiences using the power of machine-based intelligence. Tap into an ever-growing collection of powerful artificial intelligence algorithms for vision, speech, language, and knowledge.",
        //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),

        //};
    }


    //public static IList<Attachment> GetCardsAttachments()
    //{
    //    List<Attachment> list = new List<Attachment>();



    //    string urlAddress = "http://www.plusliga.pl";

    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
    //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

    //    if (response.StatusCode == HttpStatusCode.OK)
    //    {
    //        Stream receiveStream = response.GetResponseStream();
    //        StreamReader readStream = null;

    //        if (response.CharacterSet == null)
    //        {
    //            readStream = new StreamReader(receiveStream);
    //        }
    //        else
    //        {
    //            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
    //        }

    //        string data = readStream.ReadToEnd();

    //        HtmlDocument doc = new HtmlDocument();
    //        doc.LoadHtml(data);

    //        string matchResultDivId = "owl-carousel-home-slider-2";
    //        string xpath = String.Format("//div[@id='{0}']/div", matchResultDivId);
    //        var people = doc.DocumentNode.SelectNodes(xpath).Select(p => p.InnerHtml);
    //        string text = "";
    //        foreach (var person in people)
    //        {
    //            text += person;
    //        }



    //        HtmlDocument doc2 = new HtmlDocument();

    //        doc2.LoadHtml(text);
    //        var hrefList = doc2.DocumentNode.SelectNodes("//a")
    //                          .Select(p => p.GetAttributeValue("href", "not found")).Where(p => p.Contains("/news/")).GroupBy(p => p.ToString())
    //                          .ToList();

    //        var imgList = doc2.DocumentNode.SelectNodes("//img")
    //                          .Select(p => p.GetAttributeValue("src", "not found"))
    //                          .ToList();

    //        var titleList = doc2.DocumentNode.SelectNodes("//img")
    //                          .Select(p => p.GetAttributeValue("alt", "not found"))
    //                          .ToList();

    //        response.Close();
    //        readStream.Close();


    //        for (int i = 0; i < hrefList.Count; i++)
    //        {
    //            list.Add(GetHeroCard(
    //                   titleList[i], "", "",
    //                   new CardImage(url: imgList[i]),
    //                   new CardAction(ActionTypes.OpenUrl, "Czytaj więcej", value: "http://plusliga.pl" + hrefList[i].Key))
    //               );
    //        }
    //    }
    //    return list;
    //    //return new List<Attachment>()
    //    //{
    //    //    for(int i=0;i<5;i++)
    //    //    GetHeroCard(
    //    //        "Azure Storage",
    //    //        "Massively scalable cloud storage for your applications",
    //    //        "Store and help protect your data. Get durable, highly available data storage across the globe and pay only for what you use.",
    //    //        new CardImage(url: "https://acom.azurecomcdn.net/80C57D/cdn/mediahandler/docarticles/dpsmedia-prod/azure.microsoft.com/en-us/documentation/articles/storage-introduction/20160801042915/storage-concepts.png"),
    //    //        new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/storage/")),
    //    //  //  GetThumbnailCard(
    //    //    //    "DocumentDB",
    //    //    //    "Blazing fast, planet-scale NoSQL",
    //    //    //    "NoSQL service for highly available, globally distributed apps—take full advantage of SQL and JavaScript over document and key-value data without the hassles of on-premises or virtual machine-based cloud database options.",
    //    //    //    new CardImage(url: "https://sec.ch9.ms/ch9/29f4/beb4b953-ab91-4a31-b16a-71fb6d6829f4/WhatisAzureDocumentDB_960.jpg"),
    //    //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/documentdb/")),
    //    //    //GetHeroCard(
    //    //    //    "Azure Functions",
    //    //    //    "Process events with serverless code",
    //    //    //    "Azure Functions is a serverless event driven experience that extends the existing Azure App Service platform. These nano-services can scale based on demand and you pay only for the resources you consume.",
    //    //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
    //    //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),
    //    //    //GetThumbnailCard(
    //    //    //    "Cognitive Services",
    //    //    //    "Build powerful intelligence into your applications to enable natural and contextual interactions",
    //    //    //    "Enable natural and contextual interaction with tools that augment users' experiences using the power of machine-based intelligence. Tap into an ever-growing collection of powerful artificial intelligence algorithms for vision, speech, language, and knowledge.",
    //    //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
    //    //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),

    //    //};
    //}

    public static IList<Attachment> GetCardsAttachmentsGame()
    {
        List<Attachment> list = new List<Attachment>();

       // string urlAddress = "http://www.plusliga.pl";

       // HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
       // HttpWebResponse response = (HttpWebResponse)request.GetResponse();

       // if (response.StatusCode == HttpStatusCode.OK)
       // {
       //     Stream receiveStream = response.GetResponseStream();
       //     StreamReader readStream = null;

       //     if (response.CharacterSet == null)
       //     {
       //         readStream = new StreamReader(receiveStream);
       //     }
       //     else
       //     {
       //         readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
       //     }

       //     string data = readStream.ReadToEnd();

       //     HtmlDocument doc = new HtmlDocument();
       //     doc.LoadHtml(data);

       //     string matchResultDivId = "owl-carousel-home-slider-2";
       //     string xpath = String.Format("//div[@id='{0}']/div", matchResultDivId);
       //     var people = doc.DocumentNode.SelectNodes(xpath).Select(p => p.InnerHtml);
       //     string text = "";
       //     foreach (var person in people)
       //     {
       //         text += person;
       //     }

       //     HtmlDocument doc2 = new HtmlDocument();

       //     doc2.LoadHtml(text);
       //     var hrefList = doc2.DocumentNode.SelectNodes("//a")
       //                       .Select(p => p.GetAttributeValue("href", "not found")).Where(p => p.Contains("/news/") || p.Contains("/video/") || p.Contains("/gallery/")).GroupBy(p => p.ToString())
       //                       .ToList();

       //     //var hrefList2 = doc2.DocumentNode.SelectNodes("//a")
       //     //                  .Select(p => p.GetAttributeValue("href", "not found")).Where(p => p.Contains("/video/")).GroupBy(p => p.ToString())
       //     //                  .ToList();

       //     //var hrefList3 = doc2.DocumentNode.SelectNodes("//a")
       //     //      .Select(p => p.GetAttributeValue("href", "not found")).Where(p => p.Contains("/gallery/")).GroupBy(p => p.ToString())
       //     //      .ToList();

       //     //hrefList.AddRange(hrefList2);
       //     //hrefList.AddRange(hrefList3);

       //     var imgList = doc2.DocumentNode.SelectNodes("//img")
       //                       .Select(p => p.GetAttributeValue("src", "not found"))
       //                       .ToList();

       //     var titleList = doc2.DocumentNode.SelectNodes("//img")
       //                       .Select(p => p.GetAttributeValue("alt", "not found"))
       //                       .ToList();

       //     response.Close();
       //     readStream.Close();

       //     int index = 5;

       //     DataTable dt = GetWiadomosci();

       //     if (newUser == true)
       //     {
       //         index = 5;
       //         if (dt.Rows.Count == 0)
       //         {
       //             AddWiadomosc(hrefList);
       //         }
       //     }

       //     else
       //     {
       //         if (dt.Rows.Count > 0)
       //         {
       //             List<int> deleteList = new List<int>();
       //             var listTemp = new List<System.Linq.IGrouping<string, string>>();
       //             var listTemp2 = new List<System.Linq.IGrouping<string, string>>();
       //             for (int i = 0; i < hrefList.Count; i++)
       //             {
       //                 if (dt.Rows[dt.Rows.Count - 1]["Wiadomosc1"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc2"].ToString() != hrefList[i].Key &&
       //                     dt.Rows[dt.Rows.Count - 1]["Wiadomosc3"].ToString() != hrefList[i].Key && dt.Rows[dt.Rows.Count - 1]["Wiadomosc4"].ToString() != hrefList[i].Key
       //                     && dt.Rows[dt.Rows.Count - 1]["Wiadomosc5"].ToString() != hrefList[i].Key)
       //                 {
       //                     listTemp.Add(hrefList[i]);
       //                 }
       //                 listTemp2.Add(hrefList[i]);
       //             }
       //             hrefList = listTemp;
       //             index = hrefList.Count;
       //             AddWiadomosc(listTemp2);
       //         }
       //         else
       //         {
       //             index = 5;
       //             AddWiadomosc(hrefList);
       //         }
       //     }

       //     for (int i = 0; i < index; i++)
       //     {

       //         string link = "";
       //         if (hrefList[i].Key.Contains("http"))
       //         {
       //             link = hrefList[i].Key;
       //         }
       //         else
       //         {
       //             link = "http://plusliga.pl" + hrefList[i].Key;
       //         }



       //         //  list.Add(new Microsoft.Bot.Connector.VideoCard(titleList[i], "", "",null)
       ////     }

       // }
            list.Add(GetHeroCard(
       "Drużyna 1 vs Drużyna 2 \n     27-11-2016 20:00", "", "",
       new CardImage(url: "http://www.naziemna.info/wp-content/uploads/2016/05/logopolsatsport.jpg"),
       new CardAction(ActionTypes.PlayVideo, "Czytaj więcej", value: "https://www.youtube.com/watch?v=2gsYr2l4RJA&t=494s"),null)
   );
        list.Add(GetHeroCard(
"Drużyna 3 vs Drużyna 4 \n     27-11-2016 20:00", "", "",
new CardImage(url: "https://upload.wikimedia.org/wikipedia/commons/4/49/IPLA_small.jpg"),
new CardAction(ActionTypes.OpenUrl, "Czytaj więcej", value: "http://www.ipla.pl"),null)
);
        list.Add(GetHeroCard(
"Drużyna 5 vs Drużyna 6 \n     27-11-2016 20:00", "", "",
new CardImage(url: "http://www.naziemna.info/wp-content/uploads/2016/05/logopolsatsport.jpg"),
new CardAction(ActionTypes.OpenUrl, "Czytaj więcej", value: "http://www.polsatsport.pl"),null)
);
        return list;
        //return new List<Attachment>()
        //{
        //    for(int i=0;i<5;i++)
        //    GetHeroCard(
        //        "Azure Storage",
        //        "Massively scalable cloud storage for your applications",
        //        "Store and help protect your data. Get durable, highly available data storage across the globe and pay only for what you use.",
        //        new CardImage(url: "https://acom.azurecomcdn.net/80C57D/cdn/mediahandler/docarticles/dpsmedia-prod/azure.microsoft.com/en-us/documentation/articles/storage-introduction/20160801042915/storage-concepts.png"),
        //        new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/storage/")),
        //  //  GetThumbnailCard(
        //    //    "DocumentDB",
        //    //    "Blazing fast, planet-scale NoSQL",
        //    //    "NoSQL service for highly available, globally distributed apps—take full advantage of SQL and JavaScript over document and key-value data without the hassles of on-premises or virtual machine-based cloud database options.",
        //    //    new CardImage(url: "https://sec.ch9.ms/ch9/29f4/beb4b953-ab91-4a31-b16a-71fb6d6829f4/WhatisAzureDocumentDB_960.jpg"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/documentdb/")),
        //    //GetHeroCard(
        //    //    "Azure Functions",
        //    //    "Process events with serverless code",
        //    //    "Azure Functions is a serverless event driven experience that extends the existing Azure App Service platform. These nano-services can scale based on demand and you pay only for the resources you consume.",
        //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),
        //    //GetThumbnailCard(
        //    //    "Cognitive Services",
        //    //    "Build powerful intelligence into your applications to enable natural and contextual interactions",
        //    //    "Enable natural and contextual interaction with tools that augment users' experiences using the power of machine-based intelligence. Tap into an ever-growing collection of powerful artificial intelligence algorithms for vision, speech, language, and knowledge.",
        //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
        //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),

        //};
    }
    //public static IList<Attachment> GetCardsAttachments()
    //{
    //    List<Attachment> list = new List<Attachment>();



    //    string urlAddress = "http://www.plusliga.pl";

    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
    //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

    //    if (response.StatusCode == HttpStatusCode.OK)
    //    {
    //        Stream receiveStream = response.GetResponseStream();
    //        StreamReader readStream = null;

    //        if (response.CharacterSet == null)
    //        {
    //            readStream = new StreamReader(receiveStream);
    //        }
    //        else
    //        {
    //            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
    //        }

    //        string data = readStream.ReadToEnd();

    //        HtmlDocument doc = new HtmlDocument();
    //        doc.LoadHtml(data);

    //        string matchResultDivId = "owl-carousel-home-slider-2";
    //        string xpath = String.Format("//div[@id='{0}']/div", matchResultDivId);
    //        var people = doc.DocumentNode.SelectNodes(xpath).Select(p => p.InnerHtml);
    //        string text = "";
    //        foreach (var person in people)
    //        {
    //            text += person;
    //        }



    //        HtmlDocument doc2 = new HtmlDocument();

    //        doc2.LoadHtml(text);
    //        var hrefList = doc2.DocumentNode.SelectNodes("//a")
    //                          .Select(p => p.GetAttributeValue("href", "not found")).Where(p => p.Contains("/news/")).GroupBy(p => p.ToString())
    //                          .ToList();

    //        var imgList = doc2.DocumentNode.SelectNodes("//img")
    //                          .Select(p => p.GetAttributeValue("src", "not found"))
    //                          .ToList();

    //        var titleList = doc2.DocumentNode.SelectNodes("//img")
    //                          .Select(p => p.GetAttributeValue("alt", "not found"))
    //                          .ToList();

    //        response.Close();
    //        readStream.Close();


    //        for (int i = 0; i < hrefList.Count; i++)
    //        {
    //            list.Add(GetHeroCard(
    //                   titleList[i], "", "",
    //                   new CardImage(url: imgList[i]),
    //                   new CardAction(ActionTypes.OpenUrl, "Czytaj więcej", value: "http://plusliga.pl" + hrefList[i].Key))
    //               );
    //        }
    //    }
    //    return list;
    //    //return new List<Attachment>()
    //    //{
    //    //    for(int i=0;i<5;i++)
    //    //    GetHeroCard(
    //    //        "Azure Storage",
    //    //        "Massively scalable cloud storage for your applications",
    //    //        "Store and help protect your data. Get durable, highly available data storage across the globe and pay only for what you use.",
    //    //        new CardImage(url: "https://acom.azurecomcdn.net/80C57D/cdn/mediahandler/docarticles/dpsmedia-prod/azure.microsoft.com/en-us/documentation/articles/storage-introduction/20160801042915/storage-concepts.png"),
    //    //        new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/storage/")),
    //    //  //  GetThumbnailCard(
    //    //    //    "DocumentDB",
    //    //    //    "Blazing fast, planet-scale NoSQL",
    //    //    //    "NoSQL service for highly available, globally distributed apps—take full advantage of SQL and JavaScript over document and key-value data without the hassles of on-premises or virtual machine-based cloud database options.",
    //    //    //    new CardImage(url: "https://sec.ch9.ms/ch9/29f4/beb4b953-ab91-4a31-b16a-71fb6d6829f4/WhatisAzureDocumentDB_960.jpg"),
    //    //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/documentdb/")),
    //    //    //GetHeroCard(
    //    //    //    "Azure Functions",
    //    //    //    "Process events with serverless code",
    //    //    //    "Azure Functions is a serverless event driven experience that extends the existing Azure App Service platform. These nano-services can scale based on demand and you pay only for the resources you consume.",
    //    //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
    //    //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),
    //    //    //GetThumbnailCard(
    //    //    //    "Cognitive Services",
    //    //    //    "Build powerful intelligence into your applications to enable natural and contextual interactions",
    //    //    //    "Enable natural and contextual interaction with tools that augment users' experiences using the power of machine-based intelligence. Tap into an ever-growing collection of powerful artificial intelligence algorithms for vision, speech, language, and knowledge.",
    //    //    //    new CardImage(url: "https://azurecomcdn.azureedge.net/cvt-8636d9bb8d979834d655a5d39d1b4e86b12956a2bcfdb8beb04730b6daac1b86/images/page/services/functions/azure-functions-screenshot.png"),
    //    //    //    new CardAction(ActionTypes.OpenUrl, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),

    //    //};
    //}

    private static Attachment GetHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction, CardAction cardAction2)
    {

        if (cardAction2 != null)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction, cardAction2 },
            };

            return heroCard.ToAttachment();
        }
        else
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }
    }

    //private static Attachment GetVideoCard(string title, string subtitle, string text, MediaUrl cardImage, CardAction cardAction)
    //{
    //    var heroCard = new VideoCard
    //    {
    //        Title = title,
    //        Subtitle = subtitle,
    //        Text = text,
    //        Media = new List<MediaUrl>() { cardImage },
    //        Buttons = new List<CardAction>() { cardAction },
    //    };

    //    return heroCard.;
    //}

    public static void AddToLog(string action)
    {

        try
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO Log (Tresc) VALUES ('"+action+" "+DateTime.Now.ToString()+"')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            
        }
        catch
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO Log (Tresc) VALUES ('" + "Błąd dodawania wiadomosci do Loga" + " " + DateTime.Now.ToString() + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();
        }
    }

    public static void AddUser(string UserName,string UserId,string BotName,string BotId,string Url,byte flgTyp)
    {

        try
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "addUserPLPS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@BotName", BotName);
            cmd.Parameters.AddWithValue("@BotId", BotId);
            cmd.Parameters.AddWithValue("@UrlStr", Url);
            cmd.Parameters.AddWithValue("@flgTyp", flgTyp);
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();
        }
        catch (Exception ex)
        {
            AddToLog("Blad dodawania uzytkownika " + ex.ToString());
        }
    }
    public static void DeleteUser(Int64 UserId)
    {
        try
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "Update [dbo].[User] set flgDeleted=1 where UserId=" + UserId;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();
        }
        catch
        {
            AddToLog("Blad usuwania uzytkownika: " + UserId);
        }
    }

    public static void AddWiadomosc( List<System.Linq.IGrouping<string,string>> hrefList)
    {

        try
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO [dbo].[Wiadomosci] (Nazwa,DataUtw,Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5) VALUES ('" + "" + "','" + DateTime.Now + "','"+ hrefList[0].Key+ "','" + hrefList[1].Key + "','" + hrefList[2].Key + "','" + hrefList[3].Key + "','" + hrefList[4].Key + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();

        }
        catch (Exception ex)
        {
            AddToLog("Błąd dodawania wiadomości: "+ex.ToString());
        }
    }

    public static void AddWiadomoscOrlen(List<System.Linq.IGrouping<string, string>> hrefList)
    {

        try
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO [dbo].[WiadomosciOrlen] (Nazwa,DataUtw,Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5) VALUES ('" + "" + "','" + DateTime.Now + "','" + hrefList[0].Key + "','" + hrefList[1].Key + "','" + hrefList[2].Key + "','" + hrefList[3].Key + "','" + hrefList[4].Key + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();

        }
        catch (Exception ex)
        {
            AddToLog("Błąd dodawania wiadomości Orlen: " + ex.ToString());
        }
    }






    public static bool GetResoult()
    {
        //var request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.6/me/thread_settings?access_token=EAACEdEose0cBAEAg9QMvVYLZAZC6st5V8IDDMmAeZCfPXjKDVpzPPDXHtY9nIrqeVMnBXUciPmEvwwVflWifEQc7HYhK38nxZBcJu8UwASMz7eavGssFtyLoNP13iIL8Do0ljOamZC5bYob8gHFBP6eJtMSJvKq5BrGXp3e2Y3QN2rP15e0IY");

        try
        {
            string url = "https://graph.facebook.com/v2.6/me/thread_settings?access_token=EAAQzE8MpZA4kBAIp1ofKv8jOZBW8qbpk5ytq5vQS99zxXl1g7RUSnsZCwH40vFzJjIyq138GwCft18wGcz08u8y3C8L0nRKZAoyZBiTLacxp85ce0EIdvfO8EaMT8LOWiUWnJlElxXwZArxSOOoPUz7AXbbFaTTDigfEdptLlHQwZDZD";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"setting_type\":\"call_to_actions\"," +
                              "\"thread_state\":\"new_thread\","+
                              "\"call_to_actions:\":[\"payload\":\"USER_DEFINED_PAYLOAD\"]\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
            return true;

        }
        catch (Exception ex)
        {
            AddToLog("Błąd metody GetResoult");
            return false;
        }
    }
}
