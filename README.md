# Kalam Youth Forum
A freelance project for an NGO based in India. The website lists the activities and projects that are undertaken by the NGO for the non-registered users.  
The web-app is used by the NGO to track the activities of its chapters, members and the self help groups registered with the NGO.
Data is stored in a MsSQL DB with high availability and load balancing enabled. The web-app also offers a blood donation page on which guests can search for matching donors in case of an emergency. The blood-donation feature can be installed in mobile devices as a PWA as well.

# Case Study

How a small NGO from India started having an online presence and how they became efficient and transparent at managing their chapters through a web application.
## Client
I was tasked with creating a website for a Non-Governmental Organization, Kalam Youth Forum a few months back. The NGO aims in the empowerment of young generation boosting their skills and providing constant support to the aspirants.
## Challenges
This organisation is still in its nascent stage, but one thing that they really wanted was an online presence. They wanted to showcase the works and projects they’ve undertaken, they wanted to have a blood donation app and they wanted to have a way of managing the regional chapters and self-help groups under them.
## Solutions
When I took the project, I had a long talk with them to understand their aim from the website, their
requirements, and their budget. I suggested the client about using .Net Core as the primary
framework for the project since it’s easier to secure, has enterprise level support and is easier to
scale with high availability and load balancing because of its native Azure integration.  
The client was originally planning for a static website that just showcases their projects with few text
paragraphs and images. I advocated going with a CMS so that they can manage their own site with
minimal to no interaction with a developer in the future. Thus, the project which was originally
meant to be a simple static page started becoming a CMS. First part of the journey was visualising
the data and their relationship. Database models were created, entity relationship diagrams were
created and tweaked. Once the data relations were concrete, I moved forward with creating the
website.  

The design of the website was
sketched, a mock-up was created
and the client’s feedback was
taken.

We decided to have a carousel on
the banner, showcasing images
from the latest projects, an “About
Us” section, a section previewing
latest two projects, a signup form to
join the community and finally a
footer with newsletter sign up.  

Once the basic design was decided,
I started splitting the work into
modules so that I can
compartmentalise the work and
track the progress effectively.
One of the high priority
requirements that the client
wanted was a blog post like feature,
where they can post the updates.  

To take care of this feature, I
created a page that offers the user
to add content into the website
using a rich text editor. This enables
the regular user to create a really
customisable blog post, with images
embedded into it, with tables as
well as headings and formatting.
Everything that you can do in a
word processor is essentially
achievable in the page now. I have
added an option to upload and add
images into the post as well. All the
contents of this post are encoded and stored in the database safely.  

Now coming to the viewer portion of the project, the visitors will be navigating to this page to see
the active posts. All the projects can be previewed here in card format and a search functionality has
been provided as well.  

The client wanted the web application to be used for managing the chapters and self-help groups
under them. A challenge that the client put forward was the permission and access rules. The users
belonging to a specific chapter should not be allowed to view/edit/manage other chapters or the
groups belonging to other chapters. With the help of server rendered pages, and clever access rules
and routes for authentication and authorisation I was able to provide a user role system to the client
dividing their registered users into a few categories, each with its own privileges and restrictions. All
the new users signing up with the portal are automatically assigned a Guest privilege which can be
re-assigned by the Administrator. Now coming to signup and registration, care has been taken to
make sure only legitimate users are accessing the portal. To take care of this, all user registrations
require confirmation through email for account activation. Accounts that are not activated can’t
login to the portal at all. The same module also takes care of resetting the password using a forgot
password mail that is sent over the mail.  

The blood donation module is also added into the website, taking information from the registered
users who has provided consent to show their data in the donor list. This module is assigned as the
start page of the installable progressive web-app.  

## The Results
Client is now able to manage all the chapters and groups operating under them, the groups can
upload weekly/monthly account statement as pdf/word/excel files so that the organisers are able to
account and audit their groups. This has helped the NGO to work in an effective manner with
transparency.
