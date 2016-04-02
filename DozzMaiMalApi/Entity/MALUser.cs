using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


/*
    
    UPDATES MADE:
        
        // Update Description \\    // Update Date \\   // Updater (Use github or mal user name) \\

    -> File and class created code added            <-> 17.02.2016 : 00.12 +02.00   <-> Lolerji
    -> New constructor                              <-> 17.02.2016 : 00.26 +02.00   <-> Lolerji
    -> Authenyticate method is now public           <-> 17.02.2016 : 00.26 +02.00   <-> Lolerji
    -> Setters added to UN/PW properties            <-> 17.02.2016 : 00.26 +02.00   <-> Lolerji
    -> Migrating from WebClient to HttpClient       <-> 18.02.2016 : 08.32 +02.00   <-> Lolerji

*/


namespace DozzMaiMalApi.Entity
{
    public class MALUser
    {
        private readonly MalClient malClient;
        private readonly string verificationUrl;
        private string userName;
        private string password;
        private int? userID;
        private bool isAuthenticated;


        // -----------------------------------------------------------------------------------------------------------------------------------------------------//
        //                                                                          PROPERTIES                                                                  //
        // -----------------------------------------------------------------------------------------------------------------------------------------------------//


        /// <summary>
        /// Get the username of the current user
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }


        /// <summary>
        /// Get a boolean value indicating if the user is verified
        /// </summary>
        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }


        /// <summary>
        /// Get the password of the current user (Protected)
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Get the user id
        /// </summary>
        public int? UserID
        {
            get { return userID; }
            protected set { userID = value; }
        }

        // -----------------------------------------------------------------------------------------------------------------------------------------------------//
        //                                                                          METHODS                                                                     //
        // -----------------------------------------------------------------------------------------------------------------------------------------------------//


        /// <summary>
        /// Instantiates the MALUser class
        /// </summary>
        /// <param name="client">Web Client object that will hadle the request</param>
        public MALUser(object client)
        {
            userID = null;
            isAuthenticated = false;

            // Assign verification url
            verificationUrl = "http://myanimelist.net/api/account/verify_credentials.xml";

            malClient = client as MalClient;
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// Instantiates the MALUser class
        /// </summary>
        /// <param name="uName">User name for the authenticating user</param>
        /// <param name="pw">Password for the authenticating user</param>
        /// <param name="client">Web Client object that will hadle the request</param>
        public MALUser(string uName, string pw, object client)
        {
            // Initialize fields
            userName = uName;
            password = pw;
            userID = null;
            isAuthenticated = false;

            // Assign verification url
            verificationUrl = "http://myanimelist.net/api/account/verify_credentials.xml";

            malClient = client as MalClient;
            AuthenticateUser();     // Authenticate user
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// Authenticates the user using the given credentials
        /// </summary>
        public void AuthenticateUser()
        {
            // Convert credentials to base 64 string
            byte[] bytes = Encoding.UTF8.GetBytes(userName + ":" + password);
            string credentials = Convert.ToBase64String(bytes);

            try
            {
                // Add credentials to the header
                malClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                // Get result
                var result = malClient.HttpClient.GetAsync(verificationUrl, HttpCompletionOption.ResponseHeadersRead).Result;

                // DEBUG : Write user data
                Debug.WriteLine("UserData: " + result);

                isAuthenticated = true;
            }
            catch (Exception ex)
            {
                string msg = "Could not authenticate user: " + userName + ", Please make sure your credentials are correct\nException: " + ex.Message;
                throw new AuthenticationFailed(msg);
            }
        }
    }
}
