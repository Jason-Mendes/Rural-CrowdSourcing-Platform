import React, { useState, useEffect } from 'react';

const Comments = () => {
  const [comments, setComments] = useState([]);

  // Simulating fetching comments from an API
  useEffect(() => {
    const fetchedComments = [
      { id: 1, username: 'User1', text: 'This is the first comment.' },
      { id: 2, username: 'User2', text: 'This is another comment.' },
      // More comments...
    ];

    setComments(fetchedComments);
  }, []);

  return (
    <div>
      <h1>Comments</h1>
      {comments.map((comment) => (
        <div key={comment.id}>
          <h2>{comment.username}</h2>
          <p>{comment.text}</p>
        </div>
      ))}
    </div>
  );
}

export default Comments;
