# PWS #

Procard Proxy web service

*Procard* is a credit/debit card processor in Paraguay

### What is this repository for? ###

This webservice extends the functionality of the Procard socket (raw tcp connection to Procard) service, connects to it, queries the server and returns in JSON format for a more RESTful way to communicate to this service and allow your partner/clients for a more extensible.

Flexible enough to be aware of changes on the responses of the service, you can add new *OutParams* in the web.config suiting the changes of the Procard responses (Requests are usually immutable, changes on them don't occur without previous 3 months of warning)

* v1.0, implements:
- Creation of cards (and issues plastic printing)
- Modification of Card data
- Check balance of cards
- Make/Issue payments/returns

### How do I get set up? ###

1. Open and Build the proyect with VS2015 Community edition (start as adminsitrator, it uses local IIS to debug directly, you might change it to use IIS Expresss if desired)
2. Publish the web project in VS with the current publishing setup I've made.
3. Execute the *ProxyWebService.deploy.cmd /Y* to add it to your IIS 7(+) instance
4. Configure your username/password for Procard services in the web.config
5. Configure any routing you need in the PWS Appfolder.

### TODO ###

* Writing unit tests

### Who do I talk to? ###

* cmelgarejo :smile:


## License: **MIT** ##
https://mit-license.org/
