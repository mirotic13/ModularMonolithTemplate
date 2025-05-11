import React from 'react';

interface ToastListProps {
  messages: string[];
}

const ToastList: React.FC<ToastListProps> = ({ messages }) => {
  if (!messages.length) return null;

  return (
    <ul style={{ margin: 0, paddingLeft: '1.2rem' }}>
      {messages.map((msg, i) => (
        <li key={i}>{msg}</li>
      ))}
    </ul>
  );
};

export default ToastList;