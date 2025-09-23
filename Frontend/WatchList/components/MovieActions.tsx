'use client';

import Link from 'next/link';
import { useRouter } from 'next/navigation';
import { Edit, Trash2 } from 'lucide-react';
import toast from 'react-hot-toast';
import { useState } from 'react';
import { api } from '../lib/api';

interface Movie {
  id: number;
  title: string;
}

interface MovieActionsProps {
  movie: Movie;
}

export default function MovieActions({ movie }: MovieActionsProps) {
  const router = useRouter();
  const [isDeleting, setIsDeleting] = useState(false);

  const handleDelete = async () => {
    if (!confirm('Are you sure you want to delete this movie?')) return;

    setIsDeleting(true);
    try {
      await api.deleteMovie(movie.id);
      toast.success(`"${movie.title}" has been deleted`);
      router.push('/');
    } catch (err) {
      toast.error('Failed to delete movie');
      setIsDeleting(false);
    }
  };

  return (
    <div className="flex space-x-2">
      <Link
        href={`/edit-movie/${movie.id}`}
        className="inline-flex items-center px-4 py-2 border rounded-lg text-gray-700 bg-white hover:bg-gray-50"
      >
        <Edit className="w-4 h-4 mr-2" />
        Edit
      </Link>

      <button
        onClick={handleDelete}
        disabled={isDeleting}
        className="inline-flex items-center px-4 py-2 border border-red-300 rounded-lg text-red-700 bg-white hover:bg-red-50 disabled:opacity-50 disabled:cursor-not-allowed"
      >
        <Trash2 className="w-4 h-4 mr-2" />
        {isDeleting ? 'Deleting...' : 'Delete'}
      </button>
    </div>
  );
}
