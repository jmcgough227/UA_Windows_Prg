CREATE TABLE forum
(
	forum_id		bigint,
	username	 	varchar(16),
    post_title		varchar(50),
    post_time 		datetime,
    PRIMARY KEY (forum_id)
);

CREATE TABLE thread
(
	thread_id		bigint,
    forum_id		bigint,
    reply			varchar(160),
    username		varchar(16),
    reply_time		datetime,
    PRIMARY KEY (thread_id),
    FOREIGN KEY (forum_id) REFERENCES forum(forum_id)
);

CREATE TABLE user_accounts
(
	username		varchar(50) UNIQUE NOT NULL,
    pwd				varchar(50) NOT NULL,
    role			varchar(16),
    PRIMARY KEY (username)
);

INSERT INTO user_accounts (username, pwd, role)
VALUES ('jrm43', 'admin', 'admin');

