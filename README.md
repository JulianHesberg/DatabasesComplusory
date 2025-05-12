# Database Selection

For read operations we used MongoDb as it is much faster. This is useful when users are wanting to view listings and reviews, so when they try to load a listing they can see all
the data and reviews much quicker.

For write operations we used EfCore with MSSQL. We only required simple query operations for writes so EfCore was optimal.

# Datamodels and Storage Strategies

We created seperate models for both read and write models. 

The write models had User, Listing, Review, and Media. These were used as relations in our MSSQL database so that 
different entities could be linked to eachother.

The read modesl had ListingRead, ReviewRead, and UserRead. This were used for quick look ups. The ListingRead also contained a list of Media objects so they can quickly be displayed.

Media is stored using blob storage, so what is saved in our databases is a url pointing to where the media file is stored in the blob container.

# Caching Strategy
For caching we use an Microsoft Caching Memory for in memory caching. On Reads the entity is cached. If there is a valid cached object on subsequent reads,
the cached object is returned. So when a new user is created, the next time a listing is requested it will return the cached user. If the user is not already cached,
it will be fetched from MongoDB and be added to the cache.

It is also possible to Invalidate cached objects on updates and deletes

# CQRS
We use CQRS to seperate write operations from read operations. 

We use commands to modify the state of the databases. These are handled with dedicated command handlers for each operation.

After a succewwssful command, Domain events are published to our in memory event bus. This ensures that both databases are in the correct state. after the event is successfully published
and actions are taken, the unit of work will commit changes to the sql database.

This is a good approach, however when scaling you will need to create many different commands which will take some time, and may make it harder to maintain if you are refactoring 
different commands.

# Transaction Management
We used UnitOfWork pattern for all Write side operations for abstraction and control of the transaction life cycle.
Transactions are initiated in the event handlers. There, the UnitOfWork begins the transaction and performs all operations needed on the sql database.
If any error occurs, we use RollbackAsync to ensure data integrity. If all changes are successful (including updates to MongoDB) then the changes are commited and the 
transaction is disposed of.

